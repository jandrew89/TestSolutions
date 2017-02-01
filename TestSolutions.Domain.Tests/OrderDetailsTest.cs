using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Domain.Tests
{
    [TestFixture]
    public class OrderDetailsTest
    {
        private Order _order;
        private OrderDetail _orderDetails;

        private const int OrderId = 1;
        private const string ProductName = "TestProductName";
        private const decimal UnitPrice = 10.00m;
        private const int Quantity = 1000;
        private const decimal Total = 10000;

        [SetUp]
        public void SetUp()
        {
            _order = new Order();
            _orderDetails = new OrderDetail();
        }

        [Test]
        public void Test_OrderDetails_Set_Get_Order()
        {
            _orderDetails.Order = _order;

            Assert.That(_orderDetails.Order, Is.EqualTo(_order));
        }

        [Test]
        public void Test_OrderDetails_Set_Get_OrderId()
        {
            _orderDetails.Order = _order;
            _orderDetails.Order.OrderId = OrderId;

            Assert.That(_orderDetails.Order.OrderId, Is.EqualTo(OrderId));
        }

        [Test]
        public void Test_OrderDetails_Set_Get_ProductName()
        {
            _orderDetails.ProductName = ProductName;

            Assert.That(_orderDetails.ProductName, Is.EqualTo(ProductName));
        }

        [Test]
        public void Test_OrderDetails_Set_Get_UnitPrice()
        {
            _orderDetails.UnitPrice = UnitPrice;

            Assert.That(_orderDetails.UnitPrice, Is.EqualTo(UnitPrice));
        }

        [Test]
        public void Test_OrderDetails_Set_Get_Quantity()
        {
            _orderDetails.Quantity = Quantity;

            Assert.That(_orderDetails.Quantity, Is.EqualTo(Quantity));
        }

        [Test]
        public void Test_OrderDetails_Set_Get_Total()
        {
            _orderDetails.Total = Total;

            Assert.That(_orderDetails.Total, Is.EqualTo(Total));
        }
    }
}

