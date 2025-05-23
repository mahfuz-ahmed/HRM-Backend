using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddBankInformationCommandHandler : IRequestHandler<AddBankInformationCommand, BankInformation>
    {
        private readonly IBankInformationRepository _bankInformationRepository;

        public AddBankInformationCommandHandler(IBankInformationRepository bankInformationRepository)
        {
            _bankInformationRepository = bankInformationRepository;
        }

        public async Task<BankInformation> Handle(AddBankInformationCommand command, CancellationToken cancellationToken)
        {
            var addBankInformation = await _bankInformationRepository.AddBankInformationAsync(command.bankInformation);

            return addBankInformation;
        }

        public class UpdateBankInformationCommandHandler(IBankInformationRepository bankInformationRepository) : IRequestHandler<UpdateBankInformationCommand, BankInformation>
        {
            public async Task<BankInformation> Handle(UpdateBankInformationCommand command, CancellationToken cancellationToken)
            {
                return await bankInformationRepository.UpdateBankInformationAsync(command.bankInformationId, command.bankInformation);
            }
        }

        public class DeleteBankInformationCommandHandler(IBankInformationRepository bankInformationRepository) : IRequestHandler<DeleteBankInformationCommand, bool>
        {
            public async Task<bool> Handle(DeleteBankInformationCommand command, CancellationToken cancellationToken)
            {
                return await bankInformationRepository.DeleteBankInformationAsync(command.bankInformationId);
            }
        }
    }
}
