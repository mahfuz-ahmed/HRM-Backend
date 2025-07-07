using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record EmployeeAttendanceQuery() : IRequest<IEnumerable<EmployeeAttendance>>;
    public record GetEmployeeAttendanceByIdQuery(int id) : IRequest<EmployeeAttendance>;

}
