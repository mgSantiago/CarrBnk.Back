using CarrBnk.Financial.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Core.UseCases.Validators
{
    public class CreateFinancialPostingsValidator : AbstractValidator<CreateFinancialPostingsRequest>
    {
        public CreateFinancialPostingsValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
