using HRM.Domain;
using MediatR;


namespace HRM.Applicatin
{
    public record AddEmployeeDetailsCommand(EmployeeDetails employeeDetails) : IRequest<EmployeeDetails>;
    public record UpdateEmployeeDetailsCommand(int employeeDetailsId, EmployeeDetails employeeDetails) : IRequest<EmployeeDetails>;
    public record DeleteEmployeeDetailsCommand(int employeeDetailsId) : IRequest<bool>;
}
