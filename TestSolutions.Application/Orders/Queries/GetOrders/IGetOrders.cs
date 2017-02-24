using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Orders;

namespace TestSolutions.Application.Orders.Queries.GetOrders
{
    public interface IGetOrders
    {
        OrderModel GetOrderDetail(int orderId);
        List<OrderModel> GetOrdersList();
    }
}
