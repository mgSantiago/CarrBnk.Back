namespace CarrBnk.Redis.Services
{
    public interface ICacheService
    {
        Task<bool> AddCacheAsync(string key, object obj);
        Task<bool> RemoveCacheAsync(string key);
        Task<T> GetCacheAsync<T>(string key) where T : class;
    }
}
