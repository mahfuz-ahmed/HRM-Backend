using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record EmployeeQuery() : IRequest<IEnumerable<Employee>>;
    public record GetEmployeeByIdQuery(int id) : IRequest<Employee>;

}
