using Core.Entities;

namespace CarrBnk.Financial.Core.Ports.Repositories
{
    public interface IFinancialPostingsRepository
    {
        Task<bool> Insert(FinancialPostings client);
        Task<bool> Delete(string id);
        Task<bool> Update(FinancialPostings financialPosting);
        Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime dateTime);
    }
}
