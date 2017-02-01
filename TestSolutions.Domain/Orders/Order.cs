using TestSolutions.Domain.Customers;

namespace TestSolutions.Domain.Orders
{
    public class Order
    {

        public int OrderId { get; set; }

        public Customer Customer { get; set; }


        //public int OrderId
        //{
        //    get { return _orderId; } 
        //    private set
        //    {
        //        _orderId = value;
        //    }
        //}
    }
}