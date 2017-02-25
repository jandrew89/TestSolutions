using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Application.Customers.Queries.Abstractions
{
    public interface IGetCustomersQuery
    {
        Task<List<CustomerModel>> ExecuteAsync();
    }
}
