using HRM.Applicatin.IRepository.Authentication;
using HRM.Contracts.Authentication.Request;
using HRM.Infrastructure;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HRM.API.Controllers.Authentication
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequests request)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var jwt = _tokenService.GenerateAccessToken(user);
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtId = jwtHandler.ReadJwtToken(jwt).Id;
            var refreshToken = _tokenService.GenerateRefreshToken(user.Id, jwtId);

            _context.RefreshToken.Add(refreshToken);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                token = jwt,
                refreshToken = refreshToken.Token
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.Token);
            if (principal == null) return BadRequest("Invalid token");

            var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var storedToken = await _context.RefreshToken.FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken && rt.UserId == userId);

            if (storedToken == null || storedToken.IsRevoked || storedToken.IsUsed || storedToken.Expires < DateTime.UtcNow)
                return Unauthorized("Invalid refresh token");

            storedToken.IsUsed = true;
            _context.RefreshToken.Update(storedToken);

            var user = await _context.Employees.FindAsync(userId);
            var newJwt = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken(user.Id, newJwt);

            _context.RefreshToken.Add(newRefreshToken);
            await _context.SaveChangesAsync();

            return Ok(new { token = newJwt, refreshToken = newRefreshToken.Token });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            var token = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == refreshToken);
            if (token == null) return NotFound();

            token.IsRevoked = true;
            _context.RefreshToken.Update(token);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
