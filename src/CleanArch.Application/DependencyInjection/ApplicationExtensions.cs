using CleanArch.Application.Customers.Handlers;
using CleanArch.Data.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddAppliction(this IServiceCollection services)
        {
            services.AddDataConfg();
            services.AddMediatR(typeof(CustomerCreateCommandHandler));
            
            return services;
        }
    }
}
