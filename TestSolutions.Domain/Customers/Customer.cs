using System;
using TestSolutions.Domain.Common;

namespace TestSolutions.Domain.Customers
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    }
}