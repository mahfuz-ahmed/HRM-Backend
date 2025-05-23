using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record AddDepartmentCommand(Department department) : IRequest<Department>;
    public record UpdateDepartmentCommand(int departmentId, Department department) : IRequest<Department>;
    public record DeleteDepartmentCommand(int departmentId) : IRequest<bool>;
}
