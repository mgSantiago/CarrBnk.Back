using Core.Entities;

namespace Core.Repositories
{
    public interface IClientRepository
    {
        Task<bool> Insert(ClientEntity client);
        Task<bool> Delete(Guid clientId);
        Task<bool> Update(ClientEntity client);
        Task<IEnumerable<ClientEntity>> GetClients();
        Task<ClientEntity> GetClient(Guid? clientCode);
    }
}
