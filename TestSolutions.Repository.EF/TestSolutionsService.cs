using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TestSolutions.Application.Interfaces;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Shippers;
using TestSolutions.Repository.EF.Customers;
using TestSolutions.Repository.EF.Shippers;

namespace TestSolutions.Repository.EF
{
    public class TestSolutionsService : DbContext, IDatabaseService
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Shipper> Shippers { get; set; }

        public TestSolutionsService() : base("TestSolutions")
        {
            Database.SetInitializer(new TestSolutionsInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ShipperConfiguration());
        }
    }
}
