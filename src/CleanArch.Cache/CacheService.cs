using System;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace CleanArch.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public CacheService(IDatabase cache)
        {
            _cache = cache;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            if (!_cache.IsConnected(key))
            {
                return default;
            } 

            
            var json = await _cache.StringGetAsync(key);

            if (json.HasValue) return default(T);

            var obj = JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);

            return obj;
        }

        public async Task SetAsync(string key, object obj, int expiresIn)
        {
            if (!_cache.IsConnected(key))
            {
                return;
            }

            var json = JsonSerializer.Serialize(obj, _jsonSerializerOptions);

            await _cache.StringSetAsync(key, json, TimeSpan.FromMinutes(15));
        }

        public T Get<T>(string key) where T : class
        {
            if (!_cache.IsConnected(key))
            {
                return default;
            }

            var json = _cache.StringGet(key);
            if (json.HasValue) return default(T);

            var obj = JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);

            return obj;
        }

        public void Set(string key, object obj, int expiresIn)
        {
            if (!_cache.IsConnected(key))
            {
                return;
            }

            var json = JsonSerializer.Serialize(obj, _jsonSerializerOptions);

            _cache.StringSet(key, json, TimeSpan.FromMinutes(15));
        }
    }
}
