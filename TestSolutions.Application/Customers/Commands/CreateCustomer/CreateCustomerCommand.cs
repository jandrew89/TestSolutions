using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers.Commands.Factory;
using TestSolutions.Application.Interfaces;
using TestSolutions.Domain.Customers;

namespace TestSolutions.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDatabaseService _context;
        private readonly ICustomerFactory _factory;

        public CreateCustomerCommand(IDatabaseService context, ICustomerFactory factory)
        {
            this._context = context;
            this._factory = factory;
        }

        public void CreateCustomer(CustomerModel model)
        {
            Customer customer = _factory.Create(model);

            _context.Customers.Add(customer);

            _context.Save();
        }
    }
}
