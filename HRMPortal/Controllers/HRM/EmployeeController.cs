using HRM.Applicatin;
using HRM.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;
        public EmployeeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddEmployees")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee employee)
        {
            //var result = await _sender.Send(new AddEmployeeCommand(employee));
            //var command = new AddEmployeeCommand(employee);

            AddEmployeeCommand command = new AddEmployeeCommand(employee);  // Create Instance for pass employee to AddEmployeeCommand

            var result = await _sender.Send(new AddEmployeeCommand(employee));

            return Ok(result);
        }

        [HttpPut("UpdateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int employeeId, [FromBody] Employee employee)
        {
            var result = await _sender.Send(new UpdateEmployeeCommand(employeeId, employee));
            return Ok(result);
        }

        [HttpDelete("DeleteEmployeeById/{employeeId}")]
        public async Task<IActionResult> DeleteDoctorByIdAsync([FromRoute] int employeeId)
        {
            var result = await _sender.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var result = await _sender.Send(new EmployeeGetAllDataQuery());
            return Ok(result);
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int employeeId)
        {
            var result = await _sender.Send(new EmployeeGetDataQuery(employeeId));
            return Ok(result);
        }
    }
}
