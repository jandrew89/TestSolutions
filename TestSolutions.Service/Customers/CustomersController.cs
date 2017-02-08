using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TestSolutions.Application.Customers;
using TestSolutions.Application.Customers.Commands.CreateCustomer;
using TestSolutions.Application.Customers.Queries.Abstractions;

namespace TestSolutions.Service.Customers
{
    public class CustomersController : ApiController
    {
        private readonly IGetCustomersQuery _query;
        private readonly ICreateCustomerCommand _command;

        public CustomersController(IGetCustomersQuery query, 
            ICreateCustomerCommand command)
        {
            _command = command;
            _query = query;
        }

        
        public IEnumerable<CustomerModel> Get()
        {
            return _query.GetCustomersList();
        }

        [HttpPost]
        public HttpResponseMessage Create(CustomerModel model)
        {
            _command.CreateCustomer(model);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}