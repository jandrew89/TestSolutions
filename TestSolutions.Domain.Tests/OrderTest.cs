using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Domain.Tests
{
    [TestFixture]
    public class OrderTest
    {
        private Customer _customer;
        private Order _order;
        private Shipper _shipper;

        private const int OrderId = 1;
        private const decimal Total = 10000;
        private const string Comments = "TestComments";
        private static DateTime CreationDateTime = new DateTime(2010, 5, 3);

        [SetUp]
        public void SetUp()
        {
            _shipper = new Shipper();
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

        [Test]
        public void Test_Order_Set_Get_Shipper()
        {
            _order.Shipper = _shipper;

            Assert.That(_order.Shipper, Is.EqualTo(_shipper));
        }

        [Test]
        public void Test_Order_Set_Get_Comments()
        {
            _order.Comments = Comments;
            Assert.That(_order.Comments, Is.EqualTo(Comments));
        }

        [Test]
        public void Test_Order_Set_Get_CreationDateTime()
        {
            _order.CreationDateTime = CreationDateTime;
            Assert.That(_order.CreationDateTime, Is.EqualTo(CreationDateTime));
        }
    }
}
