using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record AddEmployeeCommand(Employee employee) : IRequest<Employee>;
    public record UpdateEmployeeCommand(int employeeId, Employee employee) : IRequest<Employee>;
    public record DeleteEmployeeCommand(int employeeId) : IRequest<bool>;
}
