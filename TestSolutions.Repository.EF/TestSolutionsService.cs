using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TestSolutions.Application.Interfaces;
using TestSolutions.Domain.Customers;
using TestSolutions.Repository.EF.Customers;

namespace TestSolutions.Repository.EF
{
    public class TestSolutionsService : DbContext, IDatabaseService
    {
        public IDbSet<Customer> Customers { get; set; }

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

        }
    }
}
