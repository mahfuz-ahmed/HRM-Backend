using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddEmployeeAttendanceCommandHandler : IRequestHandler<AddEmployeeAttendanceCommand, EmployeeAttendance>
    {
        private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;

        public AddEmployeeAttendanceCommandHandler(IEmployeeAttendanceRepository employeeAttendanceRepository)
        {
            _employeeAttendanceRepository = employeeAttendanceRepository;
        }

        public async Task<EmployeeAttendance> Handle(AddEmployeeAttendanceCommand command, CancellationToken cancellationToken)
        {
            var addEmployeeAttendance = await _employeeAttendanceRepository.AddEmployeeAttendanceAsync(command.employeeAttendance);

            return addEmployeeAttendance;
        }

        public class UpdateEmployeeAttendanceCommandHandler(IEmployeeAttendanceRepository employeeAttendanceRepository) : IRequestHandler<UpdateEmployeeAttendanceCommand, EmployeeAttendance>
        {
            public async Task<EmployeeAttendance> Handle(UpdateEmployeeAttendanceCommand command, CancellationToken cancellationToken)
            {
                return await employeeAttendanceRepository.UpdateEmployeeAttendanceAsync(command.employeeAttendanceId, command.employeeAttendance);
            }
        }

        public class DeleteEmployeeAttendanceCommandHandler(IEmployeeAttendanceRepository employeeAttendanceRepository) : IRequestHandler<DeleteEmployeeAttendanceCommand, bool>
        {
            public async Task<bool> Handle(DeleteEmployeeAttendanceCommand command, CancellationToken cancellationToken)
            {
                return await employeeAttendanceRepository.DeleteEmployeeAttendanceAsync(command.employeeAttendanceId);
            }
        }
    }
}
