using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Products;

namespace TestSolutions.Domain.ProductInventories
{
    public class ProductInventory
    {
        public int ProductInventoryId { get; set; }
        public int ProductId { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
