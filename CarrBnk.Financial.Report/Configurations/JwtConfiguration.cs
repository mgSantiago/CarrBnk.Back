using CarrBnk.Financial.Report.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationSettings = configuration.GetSection(AuthenticationSettings.Key).Get<AuthenticationSettings>();
            var key = Encoding.ASCII.GetBytes(authenticationSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidIssuer = authenticationSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            }); ;

            services.AddMvc();
        }
    }
}
