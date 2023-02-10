using StackExchange.Redis;

namespace CarrBnk.Redis.Connector
{
    internal class RedisConnector : IRedisConnector
    {
        private readonly Lazy<ConnectionMultiplexer> lazyConnection;

        public RedisConnector(string connectionString)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(connectionString);
            });
        }

        public ConnectionMultiplexer Connection => lazyConnection.Value;

        public IDatabase GetDB => Connection.GetDatabase();
    }
}
