using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestSolutions.Application.Customers;
using TestSolutions.Application.Customers.Queries.Abstractions;

namespace TestSolutions.Service.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly IGetCustomersQuery _query;
        public CustomersController(IGetCustomersQuery query)
        {
            _query = query;
        }

        public IEnumerable<CustomerModel> Get()
        {
            return _query.GetCustomersList();
        }
    }
}