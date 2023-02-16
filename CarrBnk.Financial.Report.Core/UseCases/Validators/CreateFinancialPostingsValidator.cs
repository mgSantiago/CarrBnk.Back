using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Report.Core.UseCases.Validators
{
    public class CreateFinancialPostingsValidator : AbstractValidator<CreateFinancialPostingsRequest>
    {
        public CreateFinancialPostingsValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().Length(24);
            RuleFor(x => x.Value).GreaterThan(0);
        }
    }
}
