using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestSolutions.Application.OrderDetails;
using TestSolutions.Application.OrderDetails.Queries.GetOrderDetails;

namespace TestSolutions.Service.OrderDetails
{
    public class OrderDetailsController : ApiController
    {
        private readonly IGetOrderDetails _query;

        public OrderDetailsController(IGetOrderDetails query)
        {
            this._query = query;
        }

        public async Task<OrderDetailsModel> Get(int id)
        {
            var model = await _query.ExecuteAsync(id);

            return model;
        }
    }
}