using HRM.Domain;
using MediatR;


namespace HRM.Applicatin
{
    public class EducationHistoryQueryHandler : IRequestHandler<EducationHistoryQuery, IEnumerable<EducationHistory>>
    {
        public readonly IEducationHistoryRepository _educationHistoryRepository;

        public EducationHistoryQueryHandler(IEducationHistoryRepository educationHistoryRepository)
        {
            _educationHistoryRepository = educationHistoryRepository;
        }
        public async Task<IEnumerable<EducationHistory>> Handle(EducationHistoryQuery query, CancellationToken cancellationToken)
        {
            return await _educationHistoryRepository.GetEducationHistoryAsync();
        }

        public class GetEducationHistoryByIdQueryHandler(IEducationHistoryRepository educationHistoryRepository) : IRequestHandler<GetEducationHistoryByIdQuery, EducationHistory>
        {
            public async Task<EducationHistory> Handle(GetEducationHistoryByIdQuery query, CancellationToken cancellationToken)
            {
                return await educationHistoryRepository.GetEducationHistoryByIdAsync(query.id);
            }
        }
    }
}