﻿using CarrBnk.Financial.Report.Core.Entities;

namespace CarrBnk.Financial.Report.Core.Ports.Repositories
{
    public interface IFinancialReportRepository
    {
        Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime startOfDay, DateTime endOfDay, CancellationToken cancellationToken);
    }
}
