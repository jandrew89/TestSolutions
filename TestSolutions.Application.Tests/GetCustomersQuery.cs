using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers;
using TestSolutions.Application.Customers.Commands.CreateCustomer;
using TestSolutions.Application.Customers.Commands.Factory;
using TestSolutions.Application.Customers.Queries.Abstractions;
using TestSolutions.Application.Customers.Queries.Implementations;
using TestSolutions.Application.Interfaces;
using TestSolutions.Common;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Application.Tests
{
    [TestFixture]
    public class GetCustomersQueryTests
    {
        private Customer _customer;
        private List<Customer> _customers { get; set; }
        private const int CustomerId = 1;
        private const string CompanyName = "TestCompanyName";
        private const string ContactName = "TestContactName";


        [SetUp]
        public void SetUp()
        {
            _customers = new List<Customer>();
            _customer = new Customer()
            {
                CustomerId = CustomerId,
                CompanyName = CompanyName,
                ContactName = ContactName
            };


            
        }

        [Test]
        public void Test_Execute_Should_Return_List_Of_Customers()
        {
            //ARRANGE
            IDbSet<Customer> mockData = _customers.GetQueryableMockDbSet();
            var mockDatabase = new Mock<IDatabaseService>();
            mockDatabase.Setup(c => c.Customers).Returns(mockData);
            var mockFactory = new Mock<ICustomerFactory>();
            mockFactory.Setup(c => c.Create(It.IsAny<CustomerModel>()));

            var customerCommand = new CreateCustomerCommand(mockDatabase.Object, mockFactory.Object);

            //ACT
            customerCommand.CreateCustomer(new CustomerModel());
            //ASSERT
            mockFactory.VerifyAll();
        }
    }
}
