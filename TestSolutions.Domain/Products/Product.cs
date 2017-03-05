using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.ProductCategories;
using TestSolutions.Domain.ProductInventories;

namespace TestSolutions.Domain.Products
{
    public class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.ProductInventories = new List<ProductInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public bool Discontinued { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
