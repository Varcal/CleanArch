using System;

namespace CleanArch.Domain.Customers.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        private Customer() { }

        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Active = true;
        }
    }
}