using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class DesignationQueryHandler:IRequestHandler<DesignationQuery, IEnumerable<Designation>>
    {
        public readonly IDesignationRepository _designationRepository;

        public DesignationQueryHandler(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }
        public async Task<IEnumerable<Designation>> Handle(DesignationQuery query, CancellationToken cancellationToken)
        {
            return await _designationRepository.GetDesignationAsync();
        }

        public class GetDesignationByIdQueryHandler(IDesignationRepository designationRepository) : IRequestHandler<GetDesignationByIdQuery, Designation>
        {
            public async Task<Designation> Handle(GetDesignationByIdQuery query, CancellationToken cancellationToken)
            {
                return await designationRepository.GetDesignationByIdAsync(query.id);
            }
        }
    }
}
