using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestSolutions.Application.Messaging;
using TestSolutions.Application.Orders;
using TestSolutions.Application.Orders.Commands.CreateOrder;
using TestSolutions.Application.Orders.Queries.GetOrders;
using TestSolutions.Common.ApplicationSettings;

namespace TestSolutions.Service.Orders
{
    public class OrdersController : ApiController
    {
        private readonly ICreateOrderCommand _createCommand;
        private readonly IGetOrders _query;
        private readonly IConfigurationRepository _configuration;

        public OrdersController(ICreateOrderCommand createCommand, IGetOrders query, IConfigurationRepository configuration)
        {
            this._createCommand = createCommand;
            this._query = query;
            this._configuration = configuration;
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

            CreateOrderMessagingClient client = new CreateOrderMessagingClient(_configuration);
            client.CreateConnection();
            client.AddOrderToQueue(model);
            client.Close();

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