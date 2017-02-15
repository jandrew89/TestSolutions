using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Application.Orders.Commands.Factory
{
    public interface ICreateOrderFactory
    {
        Order Create(DateTime date, Customer customer, Shipper shipper, decimal total, string comments);
    }
}
