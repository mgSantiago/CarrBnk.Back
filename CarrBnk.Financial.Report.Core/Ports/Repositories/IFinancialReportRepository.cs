using CarrBnk.Financial.Report.Core.Entities;

namespace CarrBnk.Financial.Report.Core.Ports.Repositories
{
    public interface IFinancialReportRepository
    {
        Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime startOfDay, DateTime endOfDay, CancellationToken cancellationToken);
        Task<string> Insert(FinancialPostings financialPosting, CancellationToken cancellationToken);
        Task<bool> Update(FinancialPostings financialPosting, CancellationToken cancellationToken);
    }
}
