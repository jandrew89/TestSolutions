using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.ProductCategories;

namespace TestSolutions.Repository.EF.ProductCategories
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ProductCategoryId);

            // Properties
            this.Property(t => t.ProductCategoryName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ProductCategory", "Production");
            this.Property(t => t.ProductCategoryId).HasColumnName("ProductCategoryID");
            this.Property(t => t.ProductCategoryName).HasColumnName("ProductCategoryName");

        }
    }
}
