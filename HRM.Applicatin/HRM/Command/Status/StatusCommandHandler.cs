using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddStatusCommandHandler : IRequestHandler<AddStatusCommand, Status>
    {
        private readonly IStatusRepository _statusRepository;

        public AddStatusCommandHandler(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Status> Handle(AddStatusCommand command, CancellationToken cancellationToken)
        {
            var addStatus = await _statusRepository.AddStatusAsync(command.status);

            return addStatus;
        }

        public class UpdateStatusCommandHandler(IStatusRepository statusRepository) : IRequestHandler<UpdateStatusCommand, Status>
        {
            public async Task<Status> Handle(UpdateStatusCommand command, CancellationToken cancellationToken)
            {
                return await statusRepository.UpdateStatusAsync(command.statusId, command.status);
            }
        }

        public class DeleteStatusCommandHandler(IStatusRepository statusRepository) : IRequestHandler<DeleteStatusCommand, bool>
        {
            public async Task<bool> Handle(DeleteStatusCommand command, CancellationToken cancellationToken)
            {
                return await statusRepository.DeleteStatusAsync(command.statusId);
            }
        }
    }
}
