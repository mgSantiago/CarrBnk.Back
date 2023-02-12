using Core.Entities;

namespace CarrBnk.Financial.Core.Ports.Repositories
{
    public interface IFinancialPostingsRepository
    {
        Task<string> Insert(FinancialPostings client);
        Task<bool> Delete(string id);
        Task<bool> Update(FinancialPostings financialPosting);
        Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime dateTime);
    }
}
