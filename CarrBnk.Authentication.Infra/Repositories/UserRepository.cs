using CarrBnk.Authentication.Core.Entities;
using CarrBnk.Authentication.Core.Ports.Repositories;

namespace CarrBnk.Authentication.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        //TODO: Dado obtido da memória, o correto seria criar um CRUD para o MongoDb, não foi feito pois não é o foco do projeto.
        public async Task<User> Get(string username, string password)
        {
            var users = new List<User>
            {
                new User(1, "teste", "passwd", "manager")
            };

            await Task.Yield();

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }
    }
}
