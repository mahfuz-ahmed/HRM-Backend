using HRM.Domain;
using MediatR;


namespace HRM.Applicatin
{
    public class BankInformationQueryHandler : IRequestHandler<BankInformationQuery, IEnumerable<BankInformation>>
    {
        public readonly IBankInformationRepository _bankInformationRepository;

        public BankInformationQueryHandler(IBankInformationRepository bankInformationRepository)
        {
            _bankInformationRepository = bankInformationRepository;
        }
        public async Task<IEnumerable<BankInformation>> Handle(BankInformationQuery query, CancellationToken cancellationToken)
        {
            return await _bankInformationRepository.GetBankInformationAsync();
        }

        public class GetBankInformationByIdQueryHandler(IBankInformationRepository bankInformationRepository) : IRequestHandler<GetBankInformationByIdQuery, BankInformation>
        {
            public async Task<BankInformation> Handle(GetBankInformationByIdQuery query, CancellationToken cancellationToken)
            {
                return await bankInformationRepository.GetBankInformationByIdAsync(query.id);
            }
        }
    }
}
