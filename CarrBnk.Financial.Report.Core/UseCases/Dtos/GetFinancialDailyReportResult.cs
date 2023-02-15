using System.Diagnostics.CodeAnalysis;

namespace CarrBnk.Financial.Report.Core.UseCases.Dtos
{
    [ExcludeFromCodeCoverage]
    public class GetFinancialDailyReportResult
    {
        public GetFinancialDailyReportResult(decimal dailyConsolidation, int cashInFlowMovementsCount, int cashOutFlowMovementsCount, int totalMovements)
        {
            DailyConsolidation = dailyConsolidation;
            CashInFlowMovementsCount = cashInFlowMovementsCount;
            CashOutFlowMovementsCount = cashOutFlowMovementsCount;
            TotalMovements = totalMovements;
        }

        public decimal DailyConsolidation { get; private set; }
        public int CashInFlowMovementsCount { get; private set; }
        public int CashOutFlowMovementsCount { get; private set; }
        public int TotalMovements { get; private set; }
    }
}
