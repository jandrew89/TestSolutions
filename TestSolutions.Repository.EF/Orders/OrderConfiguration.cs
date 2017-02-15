using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Repository.EF.Orders
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.Comments)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Order", "Sales");
            this.Property(t => t.OrderId).HasColumnName("OrderID");
            this.Property(t => t.Customer.CustomerId).HasColumnName("CustomerID");
            this.Property(t => t.Shipper.ShipperId).HasColumnName("ShipperID");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.CreationDateTime).HasColumnName("CreationDateTime");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.Customer.CustomerId);
            this.HasRequired(t => t.Shipper)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.Shipper.ShipperId);
        }
    }
}
