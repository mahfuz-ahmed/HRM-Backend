using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddDesignationCommandHandler : IRequestHandler<AddDesignationCommand, Designation>
    {
        private readonly IDesignationRepository _designationRepository;

        public AddDesignationCommandHandler(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        public async Task<Designation> Handle(AddDesignationCommand command, CancellationToken cancellationToken)
        {
            var addedDesignation = await _designationRepository.AddDesignationAsync(command.designation);
            return addedDesignation;
        }
    }

    public class UpdateDesignationCommandHandler(IDesignationRepository designationRepository) : IRequestHandler<UpdateDesignationCommand, Designation>
    {
        public async Task<Designation> Handle(UpdateDesignationCommand command, CancellationToken cancellationToken)
        {
            return await designationRepository.UpdateDesignationAsync(command.designationId, command.designation);
        }
    }

    public class DeleteDesignationCommandHandler(IDesignationRepository designationRepository) : IRequestHandler<DeleteDesignationCommand, bool>
    {
        public async Task<bool> Handle(DeleteDesignationCommand command, CancellationToken cancellationToken)
        {
            return await designationRepository.DeleteDesignationAsync(command.designationId);
        }
    }
}
