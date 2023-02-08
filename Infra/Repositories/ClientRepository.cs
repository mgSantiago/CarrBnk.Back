using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Infra.Context;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMapper _mapper;
        public ClientRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid clientCode)
        {
            using var context = new ApiContext();

            var client = await context.Client.FindAsync(clientCode);

            var entity = context.Client.Remove(client);

            await context.SaveChangesAsync();

            return entity != null;
        }

        public async Task<IEnumerable<ClientEntity>> GetClients()
        {
            using var context = new ApiContext();

            var list = context.Client; //No mundo real aqui teria paginação

            return await list.Select(k => new ClientEntity(k.Code, k.BusinessName, k.RegistrationNumber, k.CreationDate)).ToListAsync();
        }

        public async Task<ClientEntity> GetClient(Guid? clientCode)
        {
            using var context = new ApiContext();

            var client = await context.Client.FindAsync(clientCode);

            return _mapper.Map<ClientEntity>(client);
        }

        public async Task<bool> Insert(ClientEntity client)
        {
            using var context = new ApiContext();

            await context.Client.AddAsync(_mapper.Map<ClientModel>(client));

            context.SaveChanges();

            return true;
        }

        public async Task<bool> Update(ClientEntity client)
        {
            using var context = new ApiContext();

            var model = _mapper.Map<ClientModel>(client);

            context.Client.Update(model);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
