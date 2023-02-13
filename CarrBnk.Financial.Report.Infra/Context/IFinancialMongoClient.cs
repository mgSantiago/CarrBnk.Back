using CarrBnk.Financial.Report.Infra.Models;
using MongoDB.Driver;

namespace CarrBnk.Financial.Report.Infra.Context
{
    public interface IFinancialMongoClient
    {
        public IMongoCollection<FinancialReportModel> FinancialPostings();
    }
}
