using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record DesignationQuery() : IRequest<IEnumerable<Designation>>;
    public record GetDesignationByIdQuery(int id) : IRequest<Designation>;

}
