using System;
using System.Collections.Generic;
using TestSolutions.Domain.Common;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Domain.Customers
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}