using CarrBnk.Financial.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace CarrBnk.Financial.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static void AddHealthCheckConfiguration(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<MongoHealthCheck>("MongoDBConnectionCheck");
        }
    }
}
