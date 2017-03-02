using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Domain.DomainEvents
{
    public class CustomerEventArgs : EventArgs
    {
        private Customer _customer;

        public CustomerEventArgs(Customer customer)
        {
            this._customer = customer;
        }

        public Customer Customer { get { return _customer; } }
    }
}
