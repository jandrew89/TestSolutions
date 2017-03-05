using System;
using System.Data.Entity;
using System.Linq;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Employees;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.ProductCategories;
using TestSolutions.Domain.ProductInventories;
using TestSolutions.Domain.Products;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Repository.EF
{
    public class TestSolutionsInitializer : DropCreateDatabaseIfModelChanges<TestSolutionsService>
    {
        protected override void Seed(TestSolutionsService context)
        {
            base.Seed(context);

            CreateCustomer(context);

            CreateShipper(context);

            CreateEmployee(context);

            CreateProductCategory(context);

            CreateProduct(context);

            //CreateProductInventory(context);

            CreateSales(context);

            //CreateOrderDetails(context);
        }


        private void CreateCustomer(TestSolutionsService context)
        {
            context.Customers.Add(new Customer() { ContactName = "Colleen Dunn", CompanyName = "Best Buy" });
            context.Customers.Add(new Customer() { ContactName = "Bill McCorey", CompanyName = "Circuit City" });
            context.Customers.Add(new Customer() { ContactName = "Michael Cooper", CompanyName = "Game Stop" });
            context.SaveChanges();
        }

        private void CreateShipper(TestSolutionsService context)
        {
            context.Shippers.Add(new Shipper() { CompanyName = "DHL", ContactName = "Ricardo A. Bartra" });
            context.Shippers.Add(new Shipper() { CompanyName = "FedEx", ContactName = "Rob Carter" });
            context.Shippers.Add(new Shipper() { CompanyName = "UPS", ContactName = "Juan R. Perez" });
            context.SaveChanges();
        }

        private void CreateEmployee(TestSolutionsService context)
        {
            context.Employees.Add(new Employee() { BirthDate = DateTime.Now.AddYears(-23).AddMonths(1).AddDays(-4), FirstName = "Bob", LastName = "Laser", MiddleName = "T" });
            context.Employees.Add(new Employee() { BirthDate = DateTime.Now.AddYears(-15).AddMonths(-2).AddDays(23), FirstName = "Seth", LastName = "Fritz", MiddleName = "Dom" });
            context.Employees.Add(new Employee() { BirthDate = DateTime.Now.AddYears(-21).AddMonths(5).AddDays(1), FirstName = "Brandon", LastName = "Schutlz", MiddleName = "Comb" });
            context.SaveChanges();
        }

        private void CreateProductCategory(TestSolutionsService context)
        {
            context.ProductCategories.Add(new ProductCategory() { ProductCategoryName = "PS4 Games" });
            context.ProductCategories.Add(new ProductCategory() { ProductCategoryName = "XBOX" });
            context.SaveChanges();
        }

        private void CreateProduct(TestSolutionsService context)
        {
            var productCategoriesPS4 = context.ProductCategories.Where(pc => pc.ProductCategoryName == "PS4 Games").Select(pc => pc.ProductCategoryId).Single();
            var productCategoriesXBOX = context.ProductCategories.Where(pc => pc.ProductCategoryName == "XBOX").Select(pc => pc.ProductCategoryId).Single();


            context.Products.Add(new Product() {  ProductCategoryId = productCategoriesPS4, Description = "KOF XIV", Discontinued = false, UnitPrice = 59m, ProductName = "King of Fighters XIV" });
            context.Products.Add(new Product() {  ProductCategoryId = productCategoriesXBOX, Description = "SF V", Discontinued = false, UnitPrice = 49m, ProductName = "Street Fighter V" });
            context.Products.Add(new Product() {  ProductCategoryId = productCategoriesPS4,  Description = "GGKOF XIV", Discontinued = false, UnitPrice = 39m, ProductName = "Guilty Gear" });
            context.SaveChanges();
        }

        private void CreateProductInventory(TestSolutionsService context)
        {
            var product1 = context.Products.Where(p => p.ProductName == "King of Fighters XIV").Select(p => p.ProductId).SingleOrDefault();
            var product2 = context.Products.Where(p => p.ProductName == "Street Fighter V").Select(p => p.ProductId).SingleOrDefault();

            context.ProductInventories.Add(new ProductInventory() { ProductId = product1, EntryDate = DateTime.Now, Quantity = 1000 });
            context.ProductInventories.Add(new ProductInventory() { ProductId = product2, EntryDate = DateTime.Now, Quantity = 2000 });

            context.SaveChanges();
        }

        private void CreateSales(TestSolutionsService context)
        {
            var shippers = context.Shippers.ToList();

            var customers = context.Customers.ToList();

            var employees = context.Employees.ToList();

            context.Orders.Add(new Order()
            {
                Comments = "The Order department is shipping this package!",
                CreationDateTime = DateTime.Now.Date.AddDays(2),
                Customer = customers[0],
                Shipper = shippers[0],
                Employee = employees[0],
                Total = 1
                
            });

            context.Orders.Add(new Order()
            {
                Comments = "Engineering is still in design!",
                CreationDateTime = DateTime.Now.Date.AddDays(12),
                Customer = customers[1],
                Shipper = shippers[1],
                Employee = employees[1],
                Total = 23
            });

            context.SaveChanges();

        }

        private void CreateOrderDetails(TestSolutionsService context)
        {
            var orders = context.Orders.ToList();

            context.OrderDetails.Add(new OrderDetail()
            {
                Order = orders[0],
                ProductName = "Lab Request",
                Quantity = 1000,
                UnitPrice = 12 
            });

            context.OrderDetails.Add(new OrderDetail()
            {
                Order = orders[1],
                ProductName = "Special Audit",
                Quantity = 4000,
                UnitPrice = 11
            });
            context.SaveChanges();

        }

    }
}
