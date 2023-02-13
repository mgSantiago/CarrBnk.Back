using CarrBnk.Financial.Infra.Models;
using MongoDB.Driver;

namespace CarrBnk.Financial.Infra.Context
{
    public interface IFinancialMongoClient
    {
        public IMongoCollection<FinancialPostingModel> FinancialPostings();
    }
}
