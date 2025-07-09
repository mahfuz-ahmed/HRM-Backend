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

            var addedEmployee = await _employeeRepository.AddEmployeeAsync(command.employee);
            return addedEmployee;
        }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await _employeeRepository.UpdateEmployeeAsync(command.employeeId, command.employee);
        }
    }

    public class DeleteEmployeeCommandHandler: IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await _employeeRepository.DeleteEmployeeAsync(command.employeeId);
        }
    }
}
