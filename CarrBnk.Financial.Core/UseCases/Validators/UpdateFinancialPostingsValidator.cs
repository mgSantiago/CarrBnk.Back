using CarrBnk.Financial.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Core.UseCases.Validators
{
    public class UpdateFinancialPostingsValidator : AbstractValidator<UpdateFinancialPostingsRequest>
    {
        public UpdateFinancialPostingsValidator()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull().Length(24);
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
