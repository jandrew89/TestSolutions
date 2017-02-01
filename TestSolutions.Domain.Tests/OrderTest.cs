using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Domain.Tests
{
    [TestFixture]
    public class OrderTest
    {
        private Customer _customer;
        private Order _order;

        private const int OrderId = 1;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();
            _order = new Order();
        }

        [Test]
        public void Test_Order_Set_Get_OrderId()
        {
            _order.OrderId = OrderId;

            Assert.That(_order.OrderId, Is.EqualTo(OrderId));
        }

        [Test]
        public void Test_Order_Set_Get_Customer()
        {
            _order.Customer = _customer;

            Assert.That(_order.Customer, Is.EqualTo(_customer));
        }

        
    }
}
