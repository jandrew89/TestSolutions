using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Application.Shippers.Queries.GetShipper
{
    public interface IGetShipper
    {
        List<ShipperModel> GetShipperList();
        ShipperModel GetShipperDetail(int shipperId);
    }
}
