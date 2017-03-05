using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Employees;

namespace TestSolutions.Repository.EF.Employees
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.MiddleName)
                .HasMaxLength(25);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("Employee", "HumanResources");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
        }
    }
}
