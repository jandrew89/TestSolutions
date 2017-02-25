using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestSolutions.Application.Shippers;
using TestSolutions.Application.Shippers.Queries.GetShipper;

namespace TestSolutions.Service.Shippers
{
    public class ShippersController : ApiController
    {
        private readonly IGetShipper _query;

        public ShippersController(IGetShipper query)
        {
            _query = query;
        }

        public async Task<IEnumerable<ShipperModel>> Get()
        {
            return await _query.GetShippersListAsync();
        }

        public async Task<ShipperModel> Get(int id)
        {
            return await _query.GetShipperDetailAsync(id);
        }
    }
}