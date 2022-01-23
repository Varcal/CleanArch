using CleanArch.Api.Configurations.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArch.Api.Configurations
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddHealthChecks();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, OpenApiOptionsConfig>();
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
