using System.Text;

namespace App.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationSettings = configuration.GetSection(AuthenticationSettings.Key).Get<AuthenticationSettings>();
            var key = Encoding.ASCII.GetBytes(authenticationSettings.Secret);
        }
    }
}
