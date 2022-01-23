using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArch.Api.Configurations.OpenApi
{
    public class OpenApiOptionsConfig: IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public OpenApiOptionsConfig(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }


        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateApiInfo(description));
            }
        }

        private static OpenApiInfo CreateApiInfo(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Title = "CleanArch Sample Project",
                Version = description.ApiVersion.ToString(),
                Description = "CleanArch API Documentation",
                Contact = new OpenApiContact { Name = "Cleber Varçal", Email = "cleber.varcal@varcalsys.com.br", Url = new Uri("https://varcalsys.com.br") },
                //License = new OpenApiLicense { Name = "", Url = new Uri("") }
            };
        }
    }
}
