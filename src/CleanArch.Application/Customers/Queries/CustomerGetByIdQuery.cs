using System;
using CleanArch.Application.Customers.Models;
using MediatR;



namespace CleanArch.Application.Customers.Queries
{
    public  class CustomerGetByIdQuery: IRequest<CustomerModel>
    {
        public Guid Id { get; }

        public CustomerGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
