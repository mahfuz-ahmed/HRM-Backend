using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record EmployeeDetailsQuery() : IRequest<IEnumerable<EmployeeDetails>>;
    public record GetEmployeeDetailsByIdQuery(int id) : IRequest<EmployeeDetails>;

}
