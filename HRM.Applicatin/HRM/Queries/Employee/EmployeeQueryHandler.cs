using HRM.Domain;
using MediatR;
namespace HRM.Applicatin
{
    public class EmployeeGetDataQueryHandler : IRequestHandler<EmployeeGetDataQuery,Employee>
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeGetDataQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Handle(EmployeeGetDataQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.EmployeeGetDataAsync(query.id);
        }
    }

    public class EmployeeGetAllDataQueryHandler : IRequestHandler<EmployeeGetAllDataQuery, IEnumerable<Employee>>
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeGetAllDataQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Handle(EmployeeGetAllDataQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.EmployeeGetAllDataAsync();
        }
    }
}
