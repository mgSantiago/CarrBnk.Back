using AutoMapper;
using CarrBnk.Financial.Core.Repositories;
using Core.Entities;
using Infra.Models;

namespace Infra.Repositories
{
    public class FinancialPostingsRepository : IFinancialPostingsRepository
    {
        private readonly IMapper _mapper;
        public FinancialPostingsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid Code)
        {
            return true;
        }

        public async Task<IEnumerable<FinancialPostings>> GetDailyConsolidated(Guid? clientCode)
        {
            using var context = new ApiContext();

            var client = await context.Client.FindAsync(clientCode);

            return _mapper.Map<ClientEntity>(client);
        }

        public async Task<bool> Insert(FinancialPostings client)
        {
            using var context = new ApiContext();

            await context.Client.AddAsync(_mapper.Map<FinancialPostingModel>(client));

            context.SaveChanges();

            return true;
        }
    }
}
