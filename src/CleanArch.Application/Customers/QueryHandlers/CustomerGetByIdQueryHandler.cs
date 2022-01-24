using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Application.Customers.Models;
using CleanArch.Application.Customers.Queries;
using CleanArch.Domain.Customers.Interfaces.Repositories;
using MediatR;

namespace CleanArch.Application.Customers.QueryHandlers
{
    public class CustomerGetByIdQueryHandler: IRequestHandler<CustomerGetByIdQuery, CustomerModel>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerGetByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerModel> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null) return null;

            return new CustomerModel(customer);
        }
    }
}
