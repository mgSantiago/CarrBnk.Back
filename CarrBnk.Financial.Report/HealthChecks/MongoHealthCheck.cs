using CarrBnk.Financial.Report.Infra.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrBnk.Financial.Report.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IMongoDatabase _db;
        public readonly MongoClient _mongoClient;

        public MongoHealthCheck(IOptionsMonitor<MongoSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.CurrentValue.ConnectionString);

            _db = _mongoClient.GetDatabase(configuration.CurrentValue.DatabaseName);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            var healthCheckResultHealthy = await CheckMongoDBConnectionAsync();


            if (healthCheckResultHealthy)
            {
                return HealthCheckResult.Healthy("MongoDB health check success");
            }

            return HealthCheckResult.Unhealthy("MongoDB health check failure");
        }

        private async Task<bool> CheckMongoDBConnectionAsync()
        {
            try
            {
                await _db.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
            }

            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
