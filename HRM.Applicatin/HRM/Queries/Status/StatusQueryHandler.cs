using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class StatusQueryHandler : IRequestHandler<StatusQuery, IEnumerable<Status>>
    {
        public readonly IStatusRepository _statusRepository;

        public StatusQueryHandler(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public async Task<IEnumerable<Status>> Handle(StatusQuery query, CancellationToken cancellationToken)
        {
            return await _statusRepository.GetStatusAsync();
        }

        public class GetStatusByIdQueryHandler(IStatusRepository statusRepository) : IRequestHandler<GetStatusByIdQuery, Status>
        {
            public async Task<Status> Handle(GetStatusByIdQuery query, CancellationToken cancellationToken)
            {
                return await statusRepository.GetStatusByIdAsync(query.id);
            }
        }
    }
}
