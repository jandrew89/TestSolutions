using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Products;

namespace TestSolutions.Repository.EF.Products
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Product", "Production");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ProductCategoryId).HasColumnName("ProductCategoryID");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Discontinued).HasColumnName("Discontinued");

            // Relationships
            this.HasRequired(t => t.ProductCategory)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ProductCategoryId);
        }
    }
}
