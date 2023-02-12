﻿using Core.Entities;

namespace CarrBnk.Financial.Core.Ports.Repositories
{
    public interface IFinancialPostingsRepository
    {
        Task<string> Insert(FinancialPostings client, CancellationToken cancellationToken);
        Task<bool> Delete(string id, CancellationToken cancellationToken);
        Task<bool> Update(FinancialPostings financialPosting, CancellationToken cancellationToken);
        Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime dateTime);
    }
}
