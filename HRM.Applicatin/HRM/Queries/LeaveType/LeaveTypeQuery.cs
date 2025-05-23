using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record LeaveTypeQuery() : IRequest<IEnumerable<LeaveType>>;
    public record GetLeaveTypeByIdQuery(int id) : IRequest<LeaveType>;
}
