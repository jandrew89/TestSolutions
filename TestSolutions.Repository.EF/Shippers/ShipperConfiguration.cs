using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Repository.EF.Shippers
{
    public class ShipperConfiguration : EntityTypeConfiguration<Shipper>
    {
        public ShipperConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ShipperId);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(100);

            this.Property(t => t.ContactName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Shipper", "Sales");
            this.Property(t => t.ShipperId).HasColumnName("ShipperID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
        }
    }
}
