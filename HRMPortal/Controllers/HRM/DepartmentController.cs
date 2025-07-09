using ErrorOr;
using HRM.Applicatin;
using HRM.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IHttpContextAccessor contextAccessor;

        public DepartmentController(ISender sender, IHttpContextAccessor contextAccessor)
        {
            _sender = sender;
            this.contextAccessor = contextAccessor; 
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartmentAsync([FromBody] Department department)
        {
            AddDepartmentCommand command = new AddDepartmentCommand(department);  

            var result = await _sender.Send(new AddDepartmentCommand(department));

            return Ok(result);
        }

        [HttpPut("UpdateDepartment/{departmentId}")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromRoute] int departmentId, [FromBody] Department department)
        {
            var result = await _sender.Send(new UpdateDepartmentCommand(departmentId, department));
            return Ok(result);
        }

        [HttpDelete("DeleteDepartmentById/{departmentId}")]
        public async Task<IActionResult> DeleteDepartmentByIdAsync([FromRoute] int departmentId)
        {
            var result = await _sender.Send(new DeleteDepartmentCommand(departmentId));
            return Ok(result);
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var result = await _sender.Send(new DepartmentQuery());
            return Ok(result);
        }

        [HttpGet("GetDepartmentById/{departmentId}")]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromRoute] int departmentId)
        {
            //var result = await _sender.Send(new GetEmployeeByIdQuery(departmentId));
            //return Ok(result);

            var query = new GetDepartmentByIdQuery(departmentId);
            ErrorOr<Department> response = await _sender.Send(query);

            HttpContext httpContext = this.contextAccessor.HttpContext;
            var ip = httpContext.Connection?.RemoteIpAddress?.ToString();
            Console.WriteLine(ip);
            //return View();

            return response.Match(
               success => Ok(success),
               error =>
               {
                   var firstError = error.First();
                   return Problem(
                       detail: firstError.Description,
                       title: firstError.Code
                   );
               }
            );
        }
    }
}
