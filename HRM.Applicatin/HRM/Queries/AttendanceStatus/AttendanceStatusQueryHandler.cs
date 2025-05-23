using HRM.Domain;
using MediatR;


namespace HRM.Applicatin
{
    public class AttendanceStatusQueryHandler : IRequestHandler<AttendanceStatusQuery, IEnumerable<AttendanceStatus>>
    {
        public readonly IAttendanceStatusRepository _attendanceStatusRepository;

        public AttendanceStatusQueryHandler(IAttendanceStatusRepository attendanceStatusRepository)
        {
            _attendanceStatusRepository = attendanceStatusRepository;
        }
        public async Task<IEnumerable<AttendanceStatus>> Handle(AttendanceStatusQuery query, CancellationToken cancellationToken)
        {
            return await _attendanceStatusRepository.GetAttendanceStatusAsync();
        }

        public class GetAttendanceStatusByIdQueryHandler(IAttendanceStatusRepository attendanceStatusRepository) : IRequestHandler<GetAttendanceStatusByIdQuery, AttendanceStatus>
        {
            public async Task<AttendanceStatus> Handle(GetAttendanceStatusByIdQuery query, CancellationToken cancellationToken)
            {
                return await attendanceStatusRepository.GetAttendanceStatusByIdAsync(query.id);
            }
        }
    }
}