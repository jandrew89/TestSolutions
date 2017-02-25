using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestSolutions.Application.Orders;
using TestSolutions.Application.Orders.Commands.CreateOrder;
using TestSolutions.Application.Orders.Queries.GetOrders;

namespace TestSolutions.Service.Orders
{
    public class OrdersController : ApiController
    {
        private readonly ICreateOrderCommand _createCommand;
        private readonly IGetOrders _query;

        public OrdersController(ICreateOrderCommand createCommand, IGetOrders query)
        {
            this._createCommand = createCommand;
            this._query = query;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(OrderModel model)
        {
            await _createCommand.ExecuteAsync(model);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<OrderModel> Get(int id)
        {
            OrderModel model = await _query.GetOrderDetailAsync(id);

            return model;
        } 

        [HttpGet]
        public async Task<IEnumerable<OrderModel>> Get()
        {
            var models = await _query.GetOrderListAsync();
            return models;
        }
    }
}