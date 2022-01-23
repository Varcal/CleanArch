using System.Threading.Tasks;
using CleanArch.Data.Contexts;
using CleanArch.Domain.Customers.Entities;
using CleanArch.Domain.Customers.Interfaces.Repositories;

namespace CleanArch.Data.Customers.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly EfContext _db;

        public CustomerRepository(EfContext db)
        {
            _db = db;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            var result = await _db.Customers.AddAsync(customer);

            return result.Entity;
        }
    }
}
