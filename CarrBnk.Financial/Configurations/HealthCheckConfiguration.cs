using CarrBnk.Financial.HealthChecks;

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
