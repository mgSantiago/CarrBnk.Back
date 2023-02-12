using CarrBnk.Financial.Report.HealthChecks;

namespace CarrBnk.Financial.Report.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static void AddHealthCheckConfiguration(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<MongoHealthCheck>("MongoDBConnectionCheck")
                .AddCheck<RedisHealthCheck>("RedisConnectionCheck"); ;
        }
    }
}
