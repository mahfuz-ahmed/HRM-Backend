using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class PaySlipQueryHandler : IRequestHandler<PaySlipQuery, IEnumerable<PaySlip>> 
    {
        public readonly IPaySlipRepository _paySlipRepository;

        public PaySlipQueryHandler(IPaySlipRepository paySlipRepository)
        {
            _paySlipRepository = paySlipRepository;
        }
        public async Task<IEnumerable<PaySlip>> Handle(PaySlipQuery query, CancellationToken cancellationToken)
        {
            return await _paySlipRepository.GetPaySlipAsync();
        }

        public class GetPaySlipByIdQueryHandler(IPaySlipRepository paySlipRepository) : IRequestHandler<GetPaySlipByIdQuery, PaySlip>
        {
            public async Task<PaySlip> Handle(GetPaySlipByIdQuery query, CancellationToken cancellationToken)
            {
                return await paySlipRepository.GetPaySlipByIdAsync(query.id);
            }
        }
    }
}
