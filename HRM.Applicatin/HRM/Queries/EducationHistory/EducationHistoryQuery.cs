using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record EducationHistoryQuery() : IRequest<IEnumerable<EducationHistory>>;
    public record GetEducationHistoryByIdQuery(int id) : IRequest<EducationHistory>;
}
