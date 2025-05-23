using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class EducationHistoryCommandHandler: IRequestHandler<AddEducationHistoryCommand, EducationHistory>
    {
        private readonly IEducationHistoryRepository _educationHistoryRepository;

        public EducationHistoryCommandHandler(IEducationHistoryRepository educationHistoryRepository)
        {
            _educationHistoryRepository = educationHistoryRepository;
        }

        public async Task<EducationHistory> Handle(AddEducationHistoryCommand command, CancellationToken cancellationToken)
        {
            var addEducationHistory = await _educationHistoryRepository.AddEducationHistoryAsync(command.educationHistory);

            return addEducationHistory;
        }

        public class UpdateEducationHistoryCommandHandler(IEducationHistoryRepository educationHistoryRepository) : IRequestHandler<UpdateEducationHistoryCommand, EducationHistory>
        {
            public async Task<EducationHistory> Handle(UpdateEducationHistoryCommand command, CancellationToken cancellationToken)
            {
                return await educationHistoryRepository.UpdateEducationHistoryAsync(command.educationHistoryId, command.educationHistory);
            }
        }

        public class DeleteEducationHistoryCommandHandler(IEducationHistoryRepository educationHistoryRepository) : IRequestHandler<DeleteEducationHistoryCommand, bool>
        {
            public async Task<bool> Handle(DeleteEducationHistoryCommand command, CancellationToken cancellationToken)
            {
                return await educationHistoryRepository.DeleteEducationHistoryAsync(command.educationHistoryId);
            }
        }
    }
}
