using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.ProductInventories;

namespace TestSolutions.Repository.EF.ProductInventories
{
    public class ProductInventoryConfiguration : EntityTypeConfiguration<ProductInventory>
    {
        public ProductInventoryConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ProductInventoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductInventory", "Production");
            this.Property(t => t.ProductInventoryId).HasColumnName("ProductInventoryID");
            this.Property(t => t.ProductId).HasColumnName("ProductID");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductInventories)
                .HasForeignKey(d => d.ProductId);
        }
    }
}
