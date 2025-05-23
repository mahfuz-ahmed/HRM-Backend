using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class HolidaysQueryHandler: IRequestHandler<HolidaysQuery, IEnumerable<Holidays>>
    {
        public readonly IHolidaysRepository _holidaysRepository;

        public HolidaysQueryHandler(IHolidaysRepository holidaysRepository)
        {
            _holidaysRepository = holidaysRepository;
        }
        public async Task<IEnumerable<Holidays>> Handle(HolidaysQuery query, CancellationToken cancellationToken)
        {
            return await _holidaysRepository.GetHolidaysAsync();
        }

        public class GetHolidaysByIdQueryHandler(IHolidaysRepository holidaysRepository) : IRequestHandler<GetHolidaysByIdQuery, Holidays>
        {
            public async Task<Holidays> Handle(GetHolidaysByIdQuery query, CancellationToken cancellationToken)
            {
                return await holidaysRepository.GetHolidaysByIdAsync(query.id);
            }
        }
    }
}
