using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;

namespace CarrBnk.Financial.Report.HealthChecks
{
    public class RedisHealthCheck : IHealthCheck
    {
        private readonly IConnectionMultiplexer _redisCache;
        private readonly IConfiguration _configuration;

        public RedisHealthCheck(IConnectionMultiplexer redisCache, IConfiguration configuration)
        {
            _redisCache = redisCache;
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var endPoint in _redisCache.GetEndPoints(configuredOnly: true))
                {
                    var server = _redisCache.GetServer(endPoint);

                    if (server.ServerType != ServerType.Cluster)
                    {
                        await _redisCache.GetDatabase().PingAsync();
                        await server.PingAsync();
                    }
                    else
                    {
                        var clusterInfo = await server.ExecuteAsync("CLUSTER", "INFO");

                        if (clusterInfo is object && !clusterInfo.IsNull)
                        {
                            if (!clusterInfo.ToString()!.Contains("cluster_state:ok"))
                            {
                                return new HealthCheckResult(context.Registration.FailureStatus, description: $"CLUSTER is not healthy for endpoint {endPoint}");
                            }
                        }
                        else
                        {
                            return new HealthCheckResult(context.Registration.FailureStatus, description: $"CLUSTER unhealthy for endpoint {endPoint}");
                        }
                    }
                }

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
