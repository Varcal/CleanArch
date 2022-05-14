using Bogus;
using CleanArch.Domain.Customers.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArch.DomainTests
{
    public class CustomerTests
    {
        private readonly Faker _faker;
        public CustomerTests()
        {
            _faker = new Faker();
        }

        [Fact]
        public void When_create_a_new_customer()
        {
            var name = _faker.Person.FullName;

            var customer = new Customer(name);

            customer.Should().NotBeNull();
            customer.Name.Should().NotBeNullOrWhiteSpace();
            customer.Name.Should().Be(name);
        }
    }
}
