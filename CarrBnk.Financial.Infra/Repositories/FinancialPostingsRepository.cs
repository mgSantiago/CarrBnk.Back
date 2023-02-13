using CarrBnk.Financial.Core.Entities;
using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Infra.Context;
using CarrBnk.Financial.Infra.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrBnk.Financial.Infra.Repositories
{
    public class FinancialPostingsRepository : IFinancialPostingsRepository
    {
        private readonly IFinancialMongoClient _financialMongoClient;
        public FinancialPostingsRepository(IFinancialMongoClient financialMongoClient)
        {
            _financialMongoClient = financialMongoClient;
        }
        public async Task<string> Insert(FinancialPostings financialPosting, CancellationToken cancellationToken)
        {
            var objectId = ObjectId.GenerateNewId();

            await _financialMongoClient
                .FinancialPostings()
                .InsertOneAsync(
                    new FinancialPostingModel(objectId, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.Description, financialPosting.CreationDate),
                    new InsertOneOptions(),
                    cancellationToken
                 );

            return objectId.ToString();
        }

        public async Task<bool> Update(FinancialPostings financialPosting, CancellationToken cancellationToken)
        {
            var update = Builders<FinancialPostingModel>.Update
                .Set(p => p.Value, financialPosting.Value)
                .Set(p => p.FinancialPostingType, financialPosting.FinancialPostingType)
                .Set(p => p.Description, financialPosting.Description)
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

        public async Task<bool> Delete(string id, CancellationToken cancellationToken)
        {
            await _financialMongoClient
               .FinancialPostings()
               .DeleteOneAsync(id, cancellationToken);

            return true;
        }
    }
}
