using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Interfaces;

namespace TestSolutions.Application.Orders.Queries.GetOrders
{
    public class GetOrders : IGetOrders
    {
        private IDatabaseService _context;

        public GetOrders(IDatabaseService context)
        {
            _context = context;
        }

        public async Task<OrderModel> GetOrderAsync(int orderId)
        {
            return await Task<OrderModel>.Run(() => GetOrder(orderId));
        }

        public async Task<List<OrderModel>> GetOrderListAsync()
        {
            return await Task<List<OrderModel>>.Run(() => GetOrdersList());
        }

        private OrderModel GetOrder(int orderId)
        {
            var order = _context.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => new OrderModel
                {
                    OrderId = o.OrderId,
                    Comments = o.Comments,
                    CreationDateTime = o.CreationDateTime,
                    CustomerId = o.Customer.CustomerId,
                    ShipperId = o.Shipper.ShipperId,
                    Total = o.Total
                })
                .Single();
            return order;

        }

       

        private List<OrderModel> GetOrdersList()
        {
            var orders = _context.Orders.Select(o => new OrderModel
            {
                OrderId = o.OrderId,
                Comments = o.Comments,
                CreationDateTime = o.CreationDateTime,
                CustomerId = o.Customer.CustomerId,
                ShipperId = o.Shipper.ShipperId,
                Total = o.Total
            });

            return orders.ToList();
        }
    }
}
