using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class EmployeeAttendanceQueryHandler : IRequestHandler<EmployeeAttendanceQuery, IEnumerable<EmployeeAttendance>>
    {
        public readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;

        public EmployeeAttendanceQueryHandler(IEmployeeAttendanceRepository EmployeeAttendanceRepository)
        {
            _employeeAttendanceRepository = EmployeeAttendanceRepository;
        }
        public async Task<IEnumerable<EmployeeAttendance>> Handle(EmployeeAttendanceQuery query, CancellationToken cancellationToken)
        {
            return await _employeeAttendanceRepository.GetEmployeeAttendanceAsync();
        }

        public class GetEmployeeAttendanceByIdQueryHandler(IEmployeeAttendanceRepository employeeAttendanceRepository) : IRequestHandler<GetEmployeeAttendanceByIdQuery, EmployeeAttendance>
        {
            public async Task<EmployeeAttendance> Handle(GetEmployeeAttendanceByIdQuery query, CancellationToken cancellationToken)
            {
                return await employeeAttendanceRepository.GetEmployeeAttendanceByIdAsync(query.id);
            }
        }
    }
}
