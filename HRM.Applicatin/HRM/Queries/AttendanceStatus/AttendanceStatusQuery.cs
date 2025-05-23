using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record AttendanceStatusQuery() : IRequest<IEnumerable<AttendanceStatus>>;
    public record GetAttendanceStatusByIdQuery(int id) : IRequest<AttendanceStatus>;
}

