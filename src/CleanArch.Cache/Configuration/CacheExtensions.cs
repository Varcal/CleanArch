using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Cache.Configuration
{
    public static class CacheExtensions
    {
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("RedisConnection");

            services.AddDistributedRedisCache(config =>
            {
                config.Configuration = conn;
            });

            services.AddSingleton<ICacheService, CacheService>();

            return services;
        }
    }
}
