using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Application.Customers.Models;
using CleanArch.Application.Customers.Queries;
using CleanArch.Cache;
using CleanArch.Domain.Customers.Interfaces.Repositories;
using MediatR;

namespace CleanArch.Application.Customers.QueryHandlers
{
    public class CustomerGetByIdQueryHandler: IRequestHandler<CustomerGetByIdQuery, CustomerModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICacheService _cacheService;


        public CustomerGetByIdQueryHandler(ICustomerRepository customerRepository, ICacheService cacheService)
        {
            _customerRepository = customerRepository;
            _cacheService = cacheService;
        }

        public async Task<CustomerModel> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var customerKey = "CustomerKey";

            try
            {
                var customerCache = await _cacheService.GetAsync<CustomerModel>(customerKey);

                if (customerCache != null) return customerCache;

                var customer = await _customerRepository.GetByIdAsync(request.Id);

                if (customer == null) return null;

                var model = new CustomerModel(customer);

                await _cacheService.SetAsync(customerKey, model, 1);

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var customer = await _customerRepository.GetByIdAsync(request.Id);

                if (customer == null) return null;

                var model = new CustomerModel(customer);

                return model;
            }
            
        }
    }
}
