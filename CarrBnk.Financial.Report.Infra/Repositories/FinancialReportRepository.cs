using CarrBnk.Financial.Report.Core.Entities;
using CarrBnk.Financial.Report.Core.Ports.Repositories;
using CarrBnk.Financial.Report.Infra.Context;
using CarrBnk.Financial.Report.Infra.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CarrBnk.Financial.Report.Infra.Repositories
{
    public class FinancialReportRepository : IFinancialReportRepository
    {
        private readonly IFinancialMongoClient _financialMongoClient;
        public FinancialReportRepository(IFinancialMongoClient financialMongoClient)
        {
            _financialMongoClient = financialMongoClient;
        }
        public async Task<string> Insert(FinancialPostings financialPosting, CancellationToken cancellationToken)
        {
            var objectId = ObjectId.GenerateNewId();

            await _financialMongoClient
                .FinancialPostings()
                .InsertOneAsync(
                    new FinancialReportModel(objectId, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.CreationDate),
                    new InsertOneOptions(),
                    cancellationToken
                 );

            return objectId.ToString();
        }

        public async Task<bool> Update(FinancialPostings financialPosting, CancellationToken cancellationToken)
        {
            var update = Builders<FinancialReportModel>.Update
                .Set(p => p.Value, financialPosting.Value)
                .Set(p => p.FinancialPostingType, financialPosting.FinancialPostingType)
                .Set(p => p.UpdatedDate, DateTime.UtcNow);

            await _financialMongoClient
                .FinancialPostings()
                .UpdateOneAsync(
                    k => k.Id == ObjectId.Parse(financialPosting.Code),
                    update,
                    new UpdateOptions(),
                    cancellationToken
                 );

            return true;
        }

        public async Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime date, CancellationToken cancellationToken)
        {
            return await _financialMongoClient
                .FinancialPostings()
                .AsQueryable()
                .Where(k => k.CreationDate.Value.Date == date.Date)
                .Select(k => new FinancialPostings(k.Id.ToString(), k.Value, k.FinancialPostingType, k.CreationDate.Value))
                .ToListAsync();
        }
    }
}
