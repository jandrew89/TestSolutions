using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Repository.EF.Customers
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties
            this.Property(t => t.CompanyName)
                .HasMaxLength(100);

            this.Property(t => t.ContactName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Customer", "Sales");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
        }
    }
}
