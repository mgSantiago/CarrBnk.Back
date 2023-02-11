using CarrBnk.Authentication.Core.Ports.Services;
using CarrBnk.Authentication.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Authentication.Infra.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
