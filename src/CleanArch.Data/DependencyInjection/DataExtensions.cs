using CleanArch.Data.Contexts;
using CleanArch.Data.Customers.Repositories;
using CleanArch.Domain.Customers.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Data.DependencyInjection
{
    public  static class DataExtensions
    {
        public static IServiceCollection AddDataConfg(this IServiceCollection services)
        {
            services.AddDbContext<EfContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
