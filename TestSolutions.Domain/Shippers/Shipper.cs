using TestSolutions.Domain.Common;

namespace TestSolutions.Domain.Shippers
{
    public class Shipper : IEntity
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    }
}