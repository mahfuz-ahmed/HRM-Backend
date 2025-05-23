using HRM.Domain;
using MediatR;


namespace HRM.Applicatin
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            // Add doctor to the database

            var addedEmployee = await _employeeRepository.AddEmployeeAsync(command.employee);
            return addedEmployee;
        }
    }

    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeeAsync(command.employeeId, command.employee);
        }
    }

    public class DeleteDoctorCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeeAsync(command.employeeId);
        }
    }
}
