using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Customers;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Shipper> Shippers { get; set; }
        void Save();
    }
}
