using CarrBnk.Financial.Report.Core.Enums;
using MediatR;

namespace CarrBnk.Financial.Report.Core.UseCases.Dtos
{
    public class UpdateFinancialDailyReportRequest : IRequest<bool>
    {
        public UpdateFinancialDailyReportRequest(string code, decimal value, FinancialPostingType financialPostingType)
        {
            Code = code;
            Value = value;
            FinancialPostingType = financialPostingType;
        }

        public string Code { get; set; }
        public decimal Value { get; set; }
        public FinancialPostingType FinancialPostingType { get; set; }
    }
}
