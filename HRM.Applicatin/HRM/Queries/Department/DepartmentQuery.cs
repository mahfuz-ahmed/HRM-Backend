using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record DepartmentQuery() : IRequest<IEnumerable<Department>>;
    public record GetDepartmentByIdQuery(int id) : IRequest<Department>;
}
