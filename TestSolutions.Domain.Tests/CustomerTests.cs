using NUnit.Framework;
using System;
using TestSolutions.Domain.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Domain.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private readonly Customer _customer;
        private const int CustomerId = 2;
        private const string CompanyName = "TestCompanyName";
        private const string ContactName = "TestContactName";

        public CustomerTests()
        {
            _customer = new Customer();
        }

        [Test]
        public void Test_Customer_Set_Get_CustomerId()
        {
            _customer.CustomerId = CustomerId;

            Assert.That(_customer.CustomerId, Is.EqualTo(CustomerId));
        }

        [Test]
        public void Test_Customer_Set_Get_CompanyName()
        {
            _customer.CompanyName = CompanyName;

            Assert.That(_customer.CompanyName, Is.EqualTo(CompanyName));
        }

        [Test]
        public void Test_Customer_Set_Get_ContactName()
        {
            _customer.ContactName = ContactName;

            Assert.That(_customer.ContactName, Is.EqualTo(ContactName));
        }
    }
}
