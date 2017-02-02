using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Customers.Queries.Abstractions;
using TestSolutions.Application.Interfaces;

namespace TestSolutions.Application.Customers.Queries.Implementations
{
    public class GetCustomersQuery : IGetCustomersQuery
    {
        private readonly IDatabaseService _database;

        public GetCustomersQuery(IDatabaseService database)
        {
            this._database = database;
        }

        public List<CustomerModel> GetCustomersList()
        {
            var customers = _database.Customers.Select(p => new CustomerModel()
            {
                CustomerId = p.CustomerId,
                CompanyName = p.CompanyName,
                ContactName = p.ContactName
            });

            return customers.ToList();
        }
          
    }
}
