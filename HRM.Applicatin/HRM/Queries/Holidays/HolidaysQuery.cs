using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record HolidaysQuery() : IRequest<IEnumerable<Holidays>>;
    public record GetHolidaysByIdQuery(int id) : IRequest<Holidays>;

}
