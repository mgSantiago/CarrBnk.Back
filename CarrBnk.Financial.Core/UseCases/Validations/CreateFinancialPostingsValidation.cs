using CarrBnk.Financial.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Core.UseCases.Validations
{
    public class CreateFinancialPostingsValidation : AbstractValidator<CreateFinancialPostingsRequest>
    {
        public CreateFinancialPostingsValidation()
        {
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
