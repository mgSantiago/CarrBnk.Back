using CarrBnk.Authentication.Core.Ports.Repositories;
using CarrBnk.Authentication.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Authentication.Infra.Configurations
{
    public static class RepositoryConfigurations
    {
        public static void AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
