using CarrBnk.Financial.Report.Core.UseCases.Dtos;
using FluentValidation;

namespace CarrBnk.Financial.Report.Core.UseCases.Validations
{
    public class GetFinancialDailyReportValidation : AbstractValidator<GetFinancialDailyReportRequest>
    {
        public GetFinancialDailyReportValidation()
        {
            RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
