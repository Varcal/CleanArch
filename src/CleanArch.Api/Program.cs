using CleanArch.Api.Configurations;
using CleanArch.Api.Configurations.OpenApi;
using CleanArch.Application.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

builder.Services.AddApiConfiguration()
    .AddSwaggerConfig()
    .AddApplication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseOpenApiConfig(provider);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();