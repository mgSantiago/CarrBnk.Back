using CarrBnk.Financial.Core.Ports.Repositories;
using CarrBnk.Financial.Infra.Context;
using Core.Entities;
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infra.Repositories
{
    public class FinancialPostingsRepository : IFinancialPostingsRepository
    {
        private readonly IFinancialMongoClient _financialMongoClient;
        public FinancialPostingsRepository(IFinancialMongoClient financialMongoClient)
        {
            _financialMongoClient = financialMongoClient;
        }
        public async Task<string> Insert(FinancialPostings financialPosting)
        {
            var objectId = ObjectId.GenerateNewId();

            await _financialMongoClient
                .FinancialPostings()
                .InsertOneAsync(new FinancialPostingModel(objectId, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.Description, financialPosting.CreationDate));

            return objectId.ToString();
        }

        public async Task<bool> Update(FinancialPostings financialPosting)
        {
            await _financialMongoClient
                .FinancialPostings()
                .ReplaceOneAsync(k => k.Id == ObjectId.Parse(financialPosting.Code),
                    new FinancialPostingModel(ObjectId.Parse(financialPosting.Code), financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.Description, financialPosting.CreationDate));

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await _financialMongoClient
               .FinancialPostings()
               .DeleteOneAsync(id);

            return true;
        }

        public async Task<IEnumerable<FinancialPostings>> GetDailyFinancialMovements(DateTime dateTime)
        {
            return await _financialMongoClient
                .FinancialPostings()
                .AsQueryable()
                .Where(k =>k.CreationDate.Date == dateTime.Date)
                .Select(k => new FinancialPostings(k.Id.ToString(), k.Value, k.FinancialPostingType, k.Description, k.CreationDate))
                .ToListAsync();
        }
    }
}
