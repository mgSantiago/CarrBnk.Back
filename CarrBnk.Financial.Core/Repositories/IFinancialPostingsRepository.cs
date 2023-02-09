using Core.Entities;

namespace CarrBnk.Financial.Core.Repositories
{
    public interface IFinancialPostingsRepository
    {
        Task<bool> Insert(FinancialPostings client);
        Task<bool> Delete(Guid clientId);
        Task<bool> Update(FinancialPostings client);
        Task<IEnumerable<FinancialPostings>> GetClients();
        Task<FinancialPostings> GetClient(Guid? clientCode);
    }
}
