using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CleanArch.Cache.Configuration
{
    public static class CacheExtensions
    {
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("RedisConnection");

            var multiplex = ConnectionMultiplexer.Connect(conn);

            services.AddSingleton(multiplex.GetDatabase());

            services.AddSingleton<ICacheService, CacheService>();

            return services;
        }
    }
}
