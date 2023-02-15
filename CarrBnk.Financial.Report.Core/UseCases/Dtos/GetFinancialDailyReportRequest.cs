using CarrBnk.Financial.Report.Core.Enums;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Report.Core.UseCases.Dtos
{
    [ExcludeFromCodeCoverage]
    public class GetFinancialDailyReportRequest : IRequest<GetFinancialDailyReportResult>
    {
        public DateTime Date { get; set; }
    }
}
