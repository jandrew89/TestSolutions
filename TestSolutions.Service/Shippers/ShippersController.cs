using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ShipperModel> Get()
        {
            return _query.GetShipperList();
        }

        public ShipperModel Get(int id)
        {
            return _query.GetShipperDetail(id);
        }
    }
}