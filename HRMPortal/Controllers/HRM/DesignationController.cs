using Microsoft.AspNetCore.Mvc;
using HRM.Applicatin;
using HRM.Domain;
using MediatR;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly ISender _sender;
        public DesignationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddDesignation")]
        public async Task<IActionResult> AddDesignationAsync([FromBody] Designation designation)
        {
            AddDesignationCommand command = new AddDesignationCommand(designation);

            var result = await _sender.Send(new AddDesignationCommand(designation));

            return Ok(result);
        }

        [HttpPut("UpdateDesignation/{designationId}")]
        public async Task<IActionResult> UpdateDesignationAsync([FromRoute] int designationId, [FromBody] Designation designation)
        {
            var result = await _sender.Send(new UpdateDesignationCommand(designationId, designation));
            return Ok(result);
        }

        [HttpDelete("DeleteDesignationById/{designationId}")]
        public async Task<IActionResult> DeleteDesignationByIdAsync([FromRoute] int designationId)
        {
            var result = await _sender.Send(new DeleteDesignationCommand(designationId));
            return Ok(result);
        }

        [HttpGet("GetAllDesignation")]
        public async Task<IActionResult> GetAllDesignationAsync()
        {
            var result = await _sender.Send(new DesignationQuery());
            return Ok(result);
        }

        [HttpGet("GetDesignationById/{designationId}")]
        public async Task<IActionResult> GetDesignationByIdAsync([FromRoute] int designationId)
        {
            var result = await _sender.Send(new GetDesignationByIdQuery(designationId));
            return Ok(result);
        }
    }
}
