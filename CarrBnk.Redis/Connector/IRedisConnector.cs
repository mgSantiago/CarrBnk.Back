using StackExchange.Redis;

namespace CarrBnk.Redis.Connector
{
    internal interface IRedisConnector
    {
        ConnectionMultiplexer Connection { get; }
        IDatabase GetDB { get; }
    }
}
