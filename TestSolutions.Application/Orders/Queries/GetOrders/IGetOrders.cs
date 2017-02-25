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
        Task<OrderModel> GetOrderDetailAsync(int orderId);
        Task<List<OrderModel>> GetOrderListAsync();
    }
}
