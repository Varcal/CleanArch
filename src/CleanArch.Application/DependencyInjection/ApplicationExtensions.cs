using CleanArch.Application.Customers.CommandHandlers;
using CleanArch.Application.Customers.QueryHandlers;
using CleanArch.Data.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDataConfg();

            #region Command Handlers
            services.AddMediatR(typeof(CustomerCreateCommandHandler));
            #endregion

            #region Query Handlers
            services.AddMediatR(typeof(CustomerGetByIdQueryHandler)); 
            #endregion

            return services;
        }
    }
}
