using HRM.Applicatin.Common.Exceptions;
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
            var employee = await _employeeRepository.EmployeeGetDataAsync(query.id);
            if (employee == null) 
            {
                throw new NotFoundException("Employee not found");
            }
            return employee;
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
            var employees = await _employeeRepository.EmployeeGetAllDataAsync();
            if (!employees.Any())
            {
                throw new NotFoundException("Employees not found");
            }
            return employees;
        }
    }
}
