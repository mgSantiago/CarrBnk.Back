using CarrBnk.Financial.Core.Repositories;
using CarrBnk.Financial.Infra.Context;
using Core.Entities;
using Infra.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> Insert(FinancialPostings financialPosting)
        {
            await _financialMongoClient
                .FinancialPostings()
                .InsertOneAsync(new FinancialPostingModel(financialPosting.Code, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.Description, financialPosting.CreationDate));

            return true;
        }

        public async Task<bool> Update(FinancialPostings financialPosting)
        {
            await _financialMongoClient
                .FinancialPostings()
                .ReplaceOneAsync(k => k.Id == financialPosting.Code,
                    new FinancialPostingModel(financialPosting.Code, financialPosting.Value, financialPosting.FinancialPostingType, financialPosting.Description, financialPosting.CreationDate));

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
                .Select(k => new FinancialPostings(k.Id, k.Value, k.FinancialPostingType, k.Description, k.CreationDate))
                .ToListAsync();
        }
    }
}
