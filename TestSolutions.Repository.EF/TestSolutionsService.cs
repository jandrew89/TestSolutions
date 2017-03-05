using System.Data.Entity;
using TestSolutions.Application.Interfaces;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Employees;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.ProductCategories;
using TestSolutions.Domain.ProductInventories;
using TestSolutions.Domain.Products;
using TestSolutions.Domain.Shippers;
using TestSolutions.Repository.EF.Customers;
using TestSolutions.Repository.EF.Employees;
using TestSolutions.Repository.EF.OrderDetails;
using TestSolutions.Repository.EF.Orders;
using TestSolutions.Repository.EF.ProductCategories;
using TestSolutions.Repository.EF.ProductInventories;
using TestSolutions.Repository.EF.Products;
using TestSolutions.Repository.EF.Shippers;

namespace TestSolutions.Repository.EF
{
    public class TestSolutionsService : DbContext, IDatabaseService
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Shipper> Shippers { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductCategory> ProductCategories { get; set; }
        public IDbSet<ProductInventory> ProductInventories { get; set; }

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
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailsConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductInventoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
