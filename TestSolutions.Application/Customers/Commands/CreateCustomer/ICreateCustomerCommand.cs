using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Application.Customers.Commands.CreateCustomer
{
    public interface ICreateCustomerCommand
    {
        void CreateCustomer(CustomerModel model);
    }
}
