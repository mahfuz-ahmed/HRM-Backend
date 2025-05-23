using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record BankInformationQuery() : IRequest<IEnumerable<BankInformation>>;
    public record GetBankInformationByIdQuery(int id) : IRequest<BankInformation>;
}
