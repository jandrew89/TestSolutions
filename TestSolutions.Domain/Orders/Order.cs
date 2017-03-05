using System;
using System.Collections;
using System.Collections.Generic;
using TestSolutions.Domain.Common;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Employees;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Domain.Orders
{
    public class Order : IEntity
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDateTime { get; set; }

    }
}