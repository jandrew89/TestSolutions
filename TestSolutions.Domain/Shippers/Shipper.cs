using System.Collections.Generic;
using TestSolutions.Domain.Common;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Domain.Shippers
{
    public class Shipper : IEntity
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}