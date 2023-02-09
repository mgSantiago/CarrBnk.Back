using Core.Entities;
using MongoDB.Driver;

namespace CarrBnk.Financial.Infra.Context
{
    public interface IFinancialMongoClient
    {
        public IMongoCollection<FinancialPostings> FinancialPostings();
    }
}
