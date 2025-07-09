using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddEmployeeDetailsCommandHandler : IRequestHandler<AddEmployeeDetailsCommand, EmployeeDetails>
    {
        private readonly IEmployeeDetailsRepository _employeeDetailsRepository;

        public AddEmployeeDetailsCommandHandler(IEmployeeDetailsRepository employeeDetailsRepository)
        {
            _employeeDetailsRepository = employeeDetailsRepository;
        }

        public async Task<EmployeeDetails> Handle(AddEmployeeDetailsCommand command, CancellationToken cancellationToken)
        {
            var addEmployeeDetails = await _employeeDetailsRepository.AddEmployeeDetailsAsync(command.employeeDetails);

            return addEmployeeDetails;
        }

        public class UpdateEmployeeDetailsCommandHandler(IEmployeeDetailsRepository employeeDetailsRepository) : IRequestHandler<UpdateEmployeeDetailsCommand, EmployeeDetails>
        {
            public async Task<EmployeeDetails> Handle(UpdateEmployeeDetailsCommand command, CancellationToken cancellationToken)
            {
                return await employeeDetailsRepository.UpdateEmployeeDetailsAsync(command.employeeDetailsId, command.employeeDetails);
            }
        }

        public class DeleteEmployeeDetailsCommandHandler(IEmployeeDetailsRepository employeeDetailsRepository) : IRequestHandler<DeleteEmployeeDetailsCommand, bool>
        {
            public async Task<bool> Handle(DeleteEmployeeDetailsCommand command, CancellationToken cancellationToken)
            {
                return await employeeDetailsRepository.DeleteEmployeeDetailsAsync(command.employeeDetailsId);
            }
        }
    }
}
