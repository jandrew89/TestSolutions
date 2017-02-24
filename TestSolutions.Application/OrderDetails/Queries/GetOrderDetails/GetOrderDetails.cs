using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Interfaces;

namespace TestSolutions.Application.OrderDetails.Queries.GetOrderDetails
{
    public class GetOrderDetails : IGetOrderDetails
    {
        private readonly IDatabaseService _context;

        public GetOrderDetails(IDatabaseService context)
        {
            this._context = context;
        }

        public OrderDetailsModel Execute(int orderId)
        {
            var order = _context.OrderDetails.Where(o => o.Order.OrderId == orderId).Select(od => new OrderDetailsModel
            {
                OrderId = od.Order.OrderId,
                ProductName = od.ProductName,
                Quantity = od.Quantity,
                Total = od.Total,
                UnitPrice = od.UnitPrice
            }).Single();

            return order;
        }
    }
}
