using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarrBnk.Financial.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private IMongoDatabase _db { get; set; }
        public MongoClient _mongoClient { get; set; }

        public MongoHealthCheck(IOptions<Mongosettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Connection);

            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);

        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
