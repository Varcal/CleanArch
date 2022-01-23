
using CleanArch.Application.Customers.Events;
using MediatR;

namespace CleanArch.Application.Customers.Commands
{
    public class CustomerCreateCommand:  IRequest<CustomerCreatedEvent>
    {
        public string Name { get; set; }
    }
}
