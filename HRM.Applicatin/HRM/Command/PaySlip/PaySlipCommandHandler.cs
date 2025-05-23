using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddPaySlipCommandHandler : IRequestHandler<AddPaySlipCommand, PaySlip>
    {
        private readonly IPaySlipRepository _paySlipRepository;

        public AddPaySlipCommandHandler(IPaySlipRepository paySlipRepository)
        {
            _paySlipRepository = paySlipRepository;
        }

        public async Task<PaySlip> Handle(AddPaySlipCommand command, CancellationToken cancellationToken)
        {
            var addPaySlip = await _paySlipRepository.AddPaySlipAsync(command.paySlip);

            return addPaySlip;
        }

        public class UpdatePaySlipCommandHandler(IPaySlipRepository paySlipRepository) : IRequestHandler<UpdatePaySlipCommand, PaySlip>
        {
            public async Task<PaySlip> Handle(UpdatePaySlipCommand command, CancellationToken cancellationToken)
            {
                return await paySlipRepository.UpdatePaySlipAsync(command.paySlipId, command.paySlip);
            }
        }

        public class DeletePaySlipCommandHandler(IPaySlipRepository paySlipRepository) : IRequestHandler<DeletePaySlipCommand, bool>
        {
            public async Task<bool> Handle(DeletePaySlipCommand command, CancellationToken cancellationToken)
            {
                return await paySlipRepository.DeletePaySlipAsync(command.paySlipId);
            }
        }
    }
}
