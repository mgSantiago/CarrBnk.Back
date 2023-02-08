using CarrBnk.Authentication.Core.Entities;

namespace CarrBnk.Authentication.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string username, string password);
    }
}
