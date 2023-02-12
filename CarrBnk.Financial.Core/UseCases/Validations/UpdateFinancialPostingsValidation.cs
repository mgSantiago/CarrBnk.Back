using CarrBnk.Financial.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Core.UseCases.Validations
{
    public class UpdateFinancialPostingsValidation : AbstractValidator<UpdateFinancialPostingsRequest>
    {
        public UpdateFinancialPostingsValidation()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull().Length(24);
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
