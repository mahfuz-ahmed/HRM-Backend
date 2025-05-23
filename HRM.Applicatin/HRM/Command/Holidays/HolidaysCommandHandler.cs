using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddHolidayCommandHandler : IRequestHandler<AddHolidaysCommand, Holidays>
    {
        private readonly IHolidaysRepository _holidaysRepository;

        public AddHolidayCommandHandler(IHolidaysRepository holidaysRepository)
        {
            _holidaysRepository = holidaysRepository;
        }

        public async Task<Holidays> Handle(AddHolidaysCommand command, CancellationToken cancellationToken)
        {
            var addHolidays = await _holidaysRepository.AddHolidaysAsync(command.holidays);

            return addHolidays;
        }

        public class UpdateHolidaysCommandHandler(IHolidaysRepository holidaysRepository) : IRequestHandler<UpdateHolidaysCommand, Holidays>
        {
            public async Task<Holidays> Handle(UpdateHolidaysCommand command, CancellationToken cancellationToken)
            {
                return await holidaysRepository.UpdateHolidaysAsync(command.holidayId, command.holidays);
            }
        }

        public class DeleteHolidaysCommandHandler(IHolidaysRepository holidaysRepository) : IRequestHandler<DeleteHolidaysCommand, bool>
        {
            public async Task<bool> Handle(DeleteHolidaysCommand command, CancellationToken cancellationToken)
            {
                return await holidaysRepository.DeleteHolidaysAsync(command.holidayId);
            }
        }
    }
}
