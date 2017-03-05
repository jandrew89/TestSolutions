using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Products;

namespace TestSolutions.Domain.ProductCategories
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

}
