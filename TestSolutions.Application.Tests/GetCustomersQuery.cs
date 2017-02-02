using AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers.Queries.Abstractions;
using TestSolutions.Application.Customers.Queries.Implementations;
using TestSolutions.Application.Interfaces;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Application.Tests
{
    [TestFixture]
    public class GetCustomersQueryTests
    {
        private GetCustomersQuery _query;
        private Customer _customer;
        private AutoMoqer _moq;

        private const int CustomerId = 1;
        private const string CompanyName = "TestCompanyName";
        private const string ContactName = "TestContactName";


        [SetUp]
        public void SetUp()
        {
            _moq = new AutoMoqer();
            _customer = new Customer()
            {
                CustomerId = CustomerId,
                CompanyName = CompanyName,
                ContactName = ContactName
            };
           
            _moq.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .Returns(_moq.GetMock<IDbSet<Customer>>().Object);


            _query = _moq.Create<GetCustomersQuery>();
        }

        [Test]
        public void Test_Execute_Should_Return_List_Of_Customers()
        {
            var customerResults = _query.GetCustomersList();
            var cust = customerResults.Single();

            Assert.That(cust.CustomerId, Is.EqualTo(CustomerId));
            Assert.That(cust.CompanyName, Is.EqualTo(CompanyName));
            Assert.That(cust.ContactName, Is.EqualTo(ContactName));
        }
    }
}
