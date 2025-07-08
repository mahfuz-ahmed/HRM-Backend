using HRM.Applicatin;
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
            return await _employeeDetailsRepository.GetEmployeeDetailsAsync();
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
            return await _employeeDetailsRepository.GetEmployeeDetailsByIdAsync(query.id);
        }
    }
}