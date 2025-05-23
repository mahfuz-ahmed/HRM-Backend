using HRM.Applicatin;
using HRM.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AttendanceStatusController : ControllerBase
    {
        private readonly ISender _sender;

        public AttendanceStatusController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddAttendanceStatus")]
        public async Task<IActionResult> AddAttendanceStatusAsync([FromBody] AttendanceStatus attendanceStatus)
        {
            AddAttendanceStatusCommand command = new AddAttendanceStatusCommand(attendanceStatus);

            var result = await _sender.Send(new AddAttendanceStatusCommand(attendanceStatus));

            return Ok(result);
        }

        [HttpPut("UpdateAttendanceStatus/{attendanceStatusId}")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromRoute] int attendanceStatusId, [FromBody] AttendanceStatus attendanceStatus)
        {
            var result = await _sender.Send(new UpdateAttendanceStatusCommand(attendanceStatusId, attendanceStatus));
            return Ok(result);
        }

        [HttpDelete("DeleteAttendanceStatusById/{attendanceStatusId}")]
        public async Task<IActionResult> DeleteAttendanceStatusByIdAsync([FromRoute] int attendanceStatusId)
        {
            var result = await _sender.Send(new DeleteAttendanceStatusCommand(attendanceStatusId));
            return Ok(result);
        }

        [HttpGet("GetAllAttendanceStatus")]
        public async Task<IActionResult> GetAllAttendanceStatusAsync()
        {
            var result = await _sender.Send(new AttendanceStatusQuery());
            return Ok(result);
        }

        [HttpGet("GetAttendanceStatusById/{attendanceStatusId}")]
        public async Task<IActionResult> GetAttendanceStatusByIdAsync([FromRoute] int attendanceStatusId)
        {
            var result = await _sender.Send(new GetAttendanceStatusByIdQuery(attendanceStatusId));
            return Ok(result);
        }
    }
}
