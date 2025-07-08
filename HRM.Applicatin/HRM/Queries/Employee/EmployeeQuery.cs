using ErrorOr;
using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    //public record EmployeeQuery() : IRequest<IEnumerable<Employee>>;
    //public record GetEmployeeByIdQuery(int id) : IRequest<Employee>;

    public record EmployeeGetDataQuery(int id) : IRequest<Employee>;
    public record EmployeeGetAllDataQuery() : IRequest<IEnumerable<Employee>>;
    public record EmployeeDuplicateCheckQuery(string checkData) : IRequest<ErrorOr<bool>>;
}
