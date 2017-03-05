using System.Data.Entity;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Employees;
using TestSolutions.Domain.OrderDetails;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.ProductCategories;
using TestSolutions.Domain.ProductInventories;
using TestSolutions.Domain.Products;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Shipper> Shippers { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<OrderDetail> OrderDetails { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<ProductCategory> ProductCategories { get; set; }
        IDbSet<ProductInventory> ProductInventories { get; set; }


        void Save();
    }
}
