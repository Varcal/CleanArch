using System;
using CleanArch.Domain.Customers.Entities;
using MediatR;

namespace CleanArch.Application.Customers.Events
{
    public class CustomerCreatedEvent: IRequest<CustomerCreatedEvent>
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool Active { get; }

        public CustomerCreatedEvent(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Active = customer.Active;
        }
    }
}
