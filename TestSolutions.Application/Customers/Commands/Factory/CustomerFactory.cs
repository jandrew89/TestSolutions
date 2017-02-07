using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Application.Customers.Commands.Factory
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer Create(CustomerModel model)
        {
            Customer customer = new Customer()
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName
            };

            return customer;
        }
    }
}
