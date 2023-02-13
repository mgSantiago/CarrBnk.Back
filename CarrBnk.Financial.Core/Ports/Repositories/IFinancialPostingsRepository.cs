using CarrBnk.Financial.Core.Entities;

namespace CarrBnk.Financial.Core.Ports.Repositories
{
    public interface IFinancialPostingsRepository
    {
        Task Insert(FinancialPostings client, CancellationToken cancellationToken);
        Task<bool> Delete(string id, CancellationToken cancellationToken);
        Task<bool> Update(FinancialPostings financialPosting, CancellationToken cancellationToken);
    }
}
