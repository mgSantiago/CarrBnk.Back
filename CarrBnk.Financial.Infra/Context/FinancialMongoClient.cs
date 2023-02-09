using CarrBnk.Financial.Infra.Settings;
using Core.Entities;
using MongoDB.Driver;

namespace CarrBnk.Financial.Infra.Context
{
    public class FinancialMongoClient : MongoClient, IFinancialMongoClient
    {
        private readonly IMongoDatabase _mongoDataBase;
        private readonly MongoSettings _mongoSettings;

        public FinancialMongoClient(MongoSettings mongoSettings) : base(mongoSettings.ConnectionString)
        {
            _mongoSettings = mongoSettings;
            _mongoDataBase = GetDatabase(mongoSettings.DatabaseName);
        }

        public IMongoCollection<FinancialPostings> FinancialPostings() => _mongoDataBase.GetCollection<FinancialPostings>(_mongoSettings.FinancialPostingsCollectionName);
    }
}
