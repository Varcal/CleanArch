using System.Threading;
using System.Threading.Tasks;
using CleanArch.Application.Customers.Commands;
using CleanArch.Application.Customers.Events;
using CleanArch.Data;
using CleanArch.Domain.Customers.Entities;
using CleanArch.Domain.Customers.Interfaces.Repositories;
using MediatR;

namespace CleanArch.Application.Customers.Handlers
{
    public class CustomerCreateCommandHandler: IRequestHandler<CustomerCreateCommand, CustomerCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreateCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerCreatedEvent> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name);

            var result = await _customerRepository.AddAsync(customer);
            _ = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CustomerCreatedEvent(result);
        }
    }
}
