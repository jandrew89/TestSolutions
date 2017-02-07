using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Repository.EF
{
    public class TestSolutionsInitializer : CreateDatabaseIfNotExists<TestSolutionsService>
    {
        protected override void Seed(TestSolutionsService context)
        {
            base.Seed(context);

            CreateCustomer(context);
        }

        private void CreateCustomer(TestSolutionsService context)
        {
            context.Customers.Add(new Customer() { ContactName = "Colleen Dunn", CompanyName = "Best Buy" });
            context.Customers.Add(new Customer() { ContactName = "Bill McCorey", CompanyName = "Circuit City" });
            context.Customers.Add(new Customer() { ContactName = "Michael Cooper", CompanyName = "Game Stop" });
            context.SaveChanges();
        }
    }
}
