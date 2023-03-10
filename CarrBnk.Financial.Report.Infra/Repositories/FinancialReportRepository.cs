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
        public async Task Insert(FinancialPostings financialPosting, CancellationToken cancellationToken)
        {
            var objectId = String.IsNullOrWhiteSpace(financialPosting.Code) ? ObjectId.GenerateNewId() : ObjectId.Parse(financialPosting.Code);

            await _financialMongoClient
                .FinancialPostings()
                .InsertOneAsync(
                    new FinancialReportModel(objectId, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.CreationDate),
                    new InsertOneOptions(),
                    cancellationToken
                 );
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

        public async Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime startOfDay, DateTime endOfDay, CancellationToken cancellationToken)
        {
            var builder = Builders<FinancialReportModel>.Filter;
            var filter = builder.Empty;

            filter &= builder.Gte(x => x.CreationDate, startOfDay);
            filter &= builder.Lt(x => x.CreationDate, endOfDay);

            var result = await _financialMongoClient
                .FinancialPostings()
                .Find(filter).ToListAsync();

            return result.Select(k => new FinancialPostings(k.Id.ToString(), k.Value, k.FinancialPostingType, k.CreationDate));
        }
    }
}
