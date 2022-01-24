using System;
using CleanArch.Domain.Customers.Entities;


namespace CleanArch.Application.Customers.Models
{
    public class CustomerModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool Active { get; }


        public CustomerModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Active = customer.Active;
        }
    }
}
