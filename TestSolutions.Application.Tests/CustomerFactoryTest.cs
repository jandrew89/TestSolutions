using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers;
using TestSolutions.Application.Customers.Commands.Factory;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Application.Tests
{
    [TestFixture]
    public class CustomerFactoryTest
    {
        private Customer _customer;
        private CustomerFactory _factory;
        private CustomerModel _customerModel;

        private const int CustomerId = 1;
        private const string CompanyName = "TestCompanyName";
        private const string ContactName = "TestContactName";

        [SetUp]
        public void SetUp()
        {
            _customerModel = new CustomerModel()
            {
                CompanyName = CompanyName,
                ContactName = ContactName,
                CustomerId = CustomerId
            };
            _customer = new Customer();
            _factory = new CustomerFactory();
        }

        [Test]
        public void Test_CustomerFactory_Should_Create_Sale()
        {
            var result = _factory.Create(_customerModel);

            Assert.That(result.CustomerId, Is.EqualTo(CustomerId));
            Assert.That(result.ContactName, Is.EqualTo(ContactName));
            Assert.That(result.CompanyName, Is.EqualTo(CompanyName));
        }
    }
}
