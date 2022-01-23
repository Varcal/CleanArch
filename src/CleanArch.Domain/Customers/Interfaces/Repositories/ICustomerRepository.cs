using System.Threading.Tasks;
using CleanArch.Domain.Customers.Entities;

namespace CleanArch.Domain.Customers.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
    }
}
