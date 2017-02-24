using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Create(OrderModel model)
        {
            _createCommand.Execute(model);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        public OrderModel Get(int id)
        {
            OrderModel model = _query.GetOrderDetail(id);

            return model;
        } 

        [HttpGet]
        public IEnumerable<OrderModel> Get()
        {
            var models = _query.GetOrdersList();
            return models;
        }
    }
}