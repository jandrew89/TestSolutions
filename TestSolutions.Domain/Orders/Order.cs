using System;
using System.Collections;
using System.Collections.Generic;
using TestSolutions.Domain.Common;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Domain.Orders
{
    public class Order : IEntity
    {


        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }

        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDateTime { get; set; }
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}