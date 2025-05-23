using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public record AddDesignationCommand(Designation designation) : IRequest<Designation>;
    public record UpdateDesignationCommand(int designationId, Designation designation) : IRequest<Designation>;
    public record DeleteDesignationCommand(int designationId) : IRequest<bool>;
}
