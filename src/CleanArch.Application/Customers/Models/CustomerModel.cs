using System;
using CleanArch.Domain.Customers.Entities;


namespace CleanArch.Application.Customers.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }


        public CustomerModel(){}
       


        public CustomerModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Active = customer.Active;
        }
    }
}
