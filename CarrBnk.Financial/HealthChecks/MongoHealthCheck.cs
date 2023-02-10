using CarrBnk.Financial.Infra.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarrBnk.Financial.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IMongoDatabase _db;
        public readonly MongoClient _mongoClient;

        public MongoHealthCheck(IOptions<MongoSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);

            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);

        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
