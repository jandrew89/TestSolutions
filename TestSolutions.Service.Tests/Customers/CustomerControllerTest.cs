using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers;
using TestSolutions.Application.Customers.Commands.CreateCustomer;
using TestSolutions.Application.Customers.Queries.Abstractions;
using TestSolutions.Service.Customers;
using System.Net;
using System.Net.Http;

namespace TestSolutions.Service.Tests.Customers
{
    [TestFixture]
    public class CustomerControllerTest
    {
        private CustomersController _controller;

        public CustomerControllerTest()
        {
            var customer = new CustomerModel();
            var query = new Mock<IGetCustomersQuery>();
            var command = new Mock<ICreateCustomerCommand>();

            query.SetupGet(q => q.ExecuteAsync()).Returns(new List<CustomerModel>());

            _controller = new CustomersController(query.Object, command.Object);
        }

        [Test]
        public void Get_Customers_ReturnCustomers()
        {
            var results = _controller.Get();
            
        }
    }
}
