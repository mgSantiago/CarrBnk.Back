using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Enums;
using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Report.Core.UseCases.Dtos
{
    [ExcludeFromCodeCoverage]
    public class GetFinancialDailyReportResult
    {
        public GetFinancialDailyReportResult(IEnumerable<FinancialPostings> financialPostings)
        {
            DailyConsolidation = financialPostings.Sum(k => k.GetRealValue());
            CashInFlowMovementsCount = financialPostings.Count(k => k.FinancialPostingType == FinancialPostingType.CashInFlow);
            CashOutFlowMovementsCount = financialPostings.Count(k => k.FinancialPostingType == FinancialPostingType.CashOutFlow);
            TotalMovements = CashInFlowMovementsCount + CashOutFlowMovementsCount;
        }

        public decimal DailyConsolidation { get; private set; }
        public int CashInFlowMovementsCount { get; private set; }
        public int CashOutFlowMovementsCount { get; private set; }
        public int TotalMovements { get; private set; }
    }
}
