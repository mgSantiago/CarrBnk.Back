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
            return await _redisConnector.GetDB.StringSetAsync(key, JsonConvert.SerializeObject(obj), new TimeSpan(2, 0, 0));
        }

        public async Task<bool> RemoveCacheAsync(string key)
        {
            return await _redisConnector.GetDB.KeyDeleteAsync(key);
        }

        public async Task<T> GetCacheAsync<T>(string key) where T : class
        {
            var cache = await _redisConnector.GetDB.StringGetAsync(key);

            if (!cache.HasValue || cache.IsNullOrEmpty) return null;

            return JsonConvert.DeserializeObject<T>(cache);
        }
    }
}
