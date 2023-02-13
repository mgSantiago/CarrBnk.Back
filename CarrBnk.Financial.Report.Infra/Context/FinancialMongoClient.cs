using CarrBnk.Financial.Report.Infra.Models;
using CarrBnk.Financial.Report.Infra.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarrBnk.Financial.Report.Infra.Context
{
    public class FinancialMongoClient : MongoClient, IFinancialMongoClient
    {
        private readonly IMongoDatabase _mongoDataBase;
        private readonly IOptionsMonitor<MongoSettings> _mongoSettings;

        public FinancialMongoClient(IOptionsMonitor<MongoSettings> mongoSettings) : base(mongoSettings.CurrentValue.ConnectionString)
        {
            _mongoSettings = mongoSettings;
            _mongoDataBase = GetDatabase(mongoSettings.CurrentValue.DatabaseName);
        }

        public IMongoCollection<FinancialReportModel> FinancialPostings() => _mongoDataBase.GetCollection<FinancialReportModel>(_mongoSettings.CurrentValue.FinancialPostingsCollectionName);
    }
}
