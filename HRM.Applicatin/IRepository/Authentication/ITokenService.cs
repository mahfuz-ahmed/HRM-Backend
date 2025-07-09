using HRM.Domain;
using HRM.Domain.Authentication;
using System.Security.Claims;

namespace HRM.Applicatin.IRepository.Authentication
{
    public interface ITokenService
    {
        string GenerateAccessToken(Employee employee);
        RefreshToken GenerateRefreshToken(int employeeId, string jwtId);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
