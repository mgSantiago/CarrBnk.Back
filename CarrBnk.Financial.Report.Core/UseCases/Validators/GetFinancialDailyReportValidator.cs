using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Report.Core.UseCases.Validators
{
    public class GetFinancialDailyReportValidator : AbstractValidator<GetFinancialDailyReportRequest>
    {
        public GetFinancialDailyReportValidator()
        {
            RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
