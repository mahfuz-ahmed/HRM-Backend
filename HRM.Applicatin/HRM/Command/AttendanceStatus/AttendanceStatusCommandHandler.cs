using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddAttendanceStatusCommandHandler : IRequestHandler<AddAttendanceStatusCommand, AttendanceStatus>
    {
        private readonly IAttendanceStatusRepository _attendanceStatusRepository;

        public AddAttendanceStatusCommandHandler(IAttendanceStatusRepository attendanceStatusRepository)
        {
            _attendanceStatusRepository = attendanceStatusRepository;
        }

        public async Task<AttendanceStatus> Handle(AddAttendanceStatusCommand command, CancellationToken cancellationToken)
        {
            var addAttendanceStatus = await _attendanceStatusRepository.AddAttendanceStatusAsync(command.attendanceStatus);

            return addAttendanceStatus;
        }

        public class UpdateAttendanceStatusCommandHandler(IAttendanceStatusRepository attendanceStatusRepository) : IRequestHandler<UpdateAttendanceStatusCommand, AttendanceStatus>
        {
            public async Task<AttendanceStatus> Handle(UpdateAttendanceStatusCommand command, CancellationToken cancellationToken)
            {
                return await attendanceStatusRepository.UpdateAttendanceStatusAsync(command.attendanceStatusId, command.attendanceStatus);
            }
        }

        public class DeleteAttendanceStatusCommandHandler(IAttendanceStatusRepository attendanceStatusRepository) : IRequestHandler<DeleteAttendanceStatusCommand, bool>
        {
            public async Task<bool> Handle(DeleteAttendanceStatusCommand command, CancellationToken cancellationToken)
            {
                return await attendanceStatusRepository.DeleteAttendanceStatusAsync(command.attendanceStatusId);
            }
        }
    }
}
