using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArch.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var json = await _cache.GetStringAsync(key);

            if (json == null) return default(T);

            var obj = JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);

            return obj;
        }

        public async Task SetAsync(string key, object obj, int expiresIn)
        {
            var json = JsonSerializer.Serialize(obj, _jsonSerializerOptions);

            await _cache.SetStringAsync(key, json, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expiresIn) });
        }

        public T Get<T>(string key) where T : class
        {
            var json = _cache.GetString(key);

            if (json == null) return default(T);

            var obj = JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);

            return obj;
        }

        public void Set(string key, object obj, int expiresIn)
        {
            var json = JsonSerializer.Serialize(obj, _jsonSerializerOptions);

            _cache.SetString(key, json, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expiresIn) });
        }
    }
}
