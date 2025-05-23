using HRM.Domain;
using MediatR;
namespace HRM.Applicatin
{
    public class EmployeeQueryHandler : IRequestHandler<EmployeeQuery, IEnumerable<Employee>>
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> Handle(EmployeeQuery query, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
    }

    public class GetDoctorsByIdQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeByIdAsync(query.id);
        }
    }
}
