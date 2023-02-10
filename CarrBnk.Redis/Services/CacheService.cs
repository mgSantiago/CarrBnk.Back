using CarrBnk.Redis.Connector;
using Newtonsoft.Json;

namespace CarrBnk.Redis.Services
{
    internal class CacheService : ICacheService
    {
        private readonly IRedisConnector _redisConnector;

        public CacheService(IRedisConnector redisConnector)
        {
            _redisConnector = redisConnector;
        }

        public async Task<bool> AddCacheAsync(string key, object obj)
        {
            return await _redisConnector.GetDB.StringSetAsync(key, JsonConvert.SerializeObject(obj));
        }

        public async Task<bool> RemoveCacheAsync(string key)
        {
            return await _redisConnector.GetDB.KeyDeleteAsync(key);
        }

        public async Task<T> GetCacheAsync<T>(string key) where T : class
        {
            var cache = await _redisConnector.GetDB.StringGetAsync(key);

            return JsonConvert.DeserializeObject<T>(cache); //TODO: Validar esta deserialização com possibilidade de nulo.
        }
    }
}
