using HRM.Applicatin;
using HRM.Applicatin.Common.Exceptions;
using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class EmployeeDetailsQueryHandler : IRequestHandler<EmployeeDetailsQuery, IEnumerable<EmployeeDetails>>
    {
        public readonly IEmployeeDetailsRepository _employeeDetailsRepository;

        public EmployeeDetailsQueryHandler(IEmployeeDetailsRepository employeeDetailsRepository)
        {
            _employeeDetailsRepository = employeeDetailsRepository;
        }

        public async Task<IEnumerable<EmployeeDetails>> Handle(EmployeeDetailsQuery query, CancellationToken cancellationToken)
        {
            var employeeDetails = await _employeeDetailsRepository.GetEmployeeDetailsAsync();
            if (!employeeDetails.Any())
            {
                throw new NotFoundException("Employees not found");
            }
            return employeeDetails;
        }
    }
    public class EmployeeDetailsByIdQueryHandler : IRequestHandler<EmployeeDetailsByIdQuery, EmployeeDetails>
    {
        public readonly IEmployeeDetailsRepository _employeeDetailsRepository;

        public EmployeeDetailsByIdQueryHandler(IEmployeeDetailsRepository employeeDetailsRepository)
        {
            _employeeDetailsRepository = employeeDetailsRepository;
        }

        public async Task<EmployeeDetails> Handle(EmployeeDetailsByIdQuery query, CancellationToken cancellationToken)
        {
            var employee =  await _employeeDetailsRepository.GetEmployeeDetailsByIdAsync(query.id);
            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }
            return employee;

        }
    }
}