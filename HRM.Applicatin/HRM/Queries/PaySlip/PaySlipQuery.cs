using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record PaySlipQuery() : IRequest<IEnumerable<PaySlip>>;
    public record GetPaySlipByIdQuery(int id) : IRequest<PaySlip>;
}
