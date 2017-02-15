using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Application.Orders
{
    public class OrderModel
    {
        public int ShipperId { get; set; }
        public int CustomerId { get; set; }

        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
