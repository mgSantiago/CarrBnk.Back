using CarrBnk.Authentication.Infra.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Authentication.Infra.Configurations
{
    public static class AuthenticationConfigurations
    {
        public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationSettings>(configuration.GetSection(AuthenticationSettings.Key));
        }
    }
}
