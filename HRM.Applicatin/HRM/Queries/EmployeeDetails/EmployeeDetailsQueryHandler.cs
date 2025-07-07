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

        public class GetEmployeeDetailsByIdQueryHandler(IEmployeeDetailsRepository employeeDetailsRepository) : IRequestHandler<GetEmployeeDetailsByIdQuery, EmployeeDetails>
        {
            public async Task<EmployeeDetails> Handle(GetEmployeeDetailsByIdQuery query, CancellationToken cancellationToken)
            {
                return await employeeDetailsRepository.GetEmployeeDetailsByIdAsync(query.id);
            }
        }
    }
}
