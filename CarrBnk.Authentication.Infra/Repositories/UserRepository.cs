using CarrBnk.Authentication.Core.Repositories;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Get(string username, string password)
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "teste1", Password = "teste1", Role = "manager" },
                new User { Id = 2, Username = "teste2", Password = "teste2", Role = "employee" }
            };

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }
    }
}
