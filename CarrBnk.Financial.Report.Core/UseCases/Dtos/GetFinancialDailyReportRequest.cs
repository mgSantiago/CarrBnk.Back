using CarrBnk.Financial.Report.Core.Enums;
using MediatR;

namespace CarrBnk.Financial.Report.Core.UseCases.Dtos
{
    public class GetFinancialDailyReportRequest : IRequest<GetFinancialDailyReportResult>
    {
        public DateTime Date { get; set; }
    }
}
