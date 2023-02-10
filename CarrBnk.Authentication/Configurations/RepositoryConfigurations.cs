using CarrBnk.Authentication.Core.Ports.Repositories;
using Infra.Repositories;

namespace CarrBnk.Authentication.Configurations
{
    public static class RepositoryConfigurations
    {
        public static void AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
