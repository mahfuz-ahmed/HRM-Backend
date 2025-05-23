using FluentValidation;

namespace HRM.Applicatin
{
 

    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator()
        {
            RuleFor(x => x.employee.Id).NotEmpty().WithMessage("DocumentID is required");
            RuleFor(x => x.employee.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.employee.FullName).NotEmpty().WithMessage("FullName is required");
        }
    }
}
