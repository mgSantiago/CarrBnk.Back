using CarrBnk.Redis.Connector;
using CarrBnk.Redis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Redis.Configurations
{
    public static class RedisConfiguration
    {
        public static void AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRedisConnector>(k => new RedisConnector(configuration.GetConnectionString("Redis") ?? string.Empty));
            services.AddScoped<ICacheService, CacheService>();
        }
    }
}
