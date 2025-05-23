using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record StatusQuery() : IRequest<IEnumerable<Status>>;
    public record GetStatusByIdQuery(int id) : IRequest<Status>;
}

