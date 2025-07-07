using HRM.Applicatin;
using HRM.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers.HRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : Controller
    {
        private readonly ISender _sender;

        public EmployeeDetailsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddEmployeeDetails")]
        public async Task<IActionResult> AddEmployeeDetailsAsync([FromBody] EmployeeDetails employeeDetails)
        {
            AddEmployeeDetailsCommand command = new AddEmployeeDetailsCommand(employeeDetails);

            var result = await _sender.Send(new AddEmployeeDetailsCommand(employeeDetails));

            return Ok(result);
        }

        [HttpPut("UpdateEmployeeDetails/{employeeDetailsId}")]
        public async Task<IActionResult> UpdateEmployeeDetailsAsync([FromRoute] int employeeDetailsId, [FromBody] EmployeeDetails employeeDetails)
        {
            var result = await _sender.Send(new UpdateEmployeeDetailsCommand(employeeDetailsId, employeeDetails));
            return Ok(result);
        }

        [HttpDelete("DeleteEmployeeDetailsById/{employeeDetailsId}")]
        public async Task<IActionResult> DeleteEmployeeDetailsByIdAsync([FromRoute] int employeeDetailsId)
        {
            var result = await _sender.Send(new DeleteEmployeeDetailsCommand(employeeDetailsId));
            return Ok(result);
        }

        [HttpGet("GetAllEmployeeDetails")]
        public async Task<IActionResult> GetAllEmployeeDetailsAsync()
        {
            var result = await _sender.Send(new EmployeeDetailsQuery());
            return Ok(result);
        }

        [HttpGet("GetEmployeeDetailsById/{employeeDetailsId}")]
        public async Task<IActionResult> GetEmployeeDetailsByIdAsync([FromRoute] int employeeDetailsId)
        {
            var result = await _sender.Send(new GetEmployeeDetailsByIdQuery(employeeDetailsId));
            return Ok(result);
        }
    }
}

