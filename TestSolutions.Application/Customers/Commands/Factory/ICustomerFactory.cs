using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Application.Customers.Commands.Factory
{
    public interface ICustomerFactory
    {
        Customer Create(CustomerModel model);
    }
}
