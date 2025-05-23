using HRM.Applicatin;
using HRM.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : ControllerBase
    {
        private readonly ISender _sender;

        public DepartmentController(ISender sender)
        {
            _sender = sender;
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
            var result = await _sender.Send(new GetEmployeeByIdQuery(departmentId));
            return Ok(result);
        }
    }
}
