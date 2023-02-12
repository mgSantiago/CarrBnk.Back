using CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Core.UseCases.CreateFinancialPostings.Validations
{
    public class CreateFinancialPostingsValidation : AbstractValidator<CreateFinancialPostingsRequest>
    {
        public CreateFinancialPostingsValidation()
        {
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        }
    }
}
