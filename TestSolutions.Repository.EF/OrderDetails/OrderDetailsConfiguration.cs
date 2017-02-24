using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.OrderDetails;

namespace TestSolutions.Repository.EF.OrderDetails
{
    public class OrderDetailsConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailsConfiguration()
        {
            this.HasKey(t => new { t.Order.OrderId});

            this.Property(t => t.Order.OrderId)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

       
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Order.OrderId).HasColumnName("OrderId");
            this.Property(t => t.ProductName).HasColumnName("ProductName");

            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.Order);
        }
    }
}
