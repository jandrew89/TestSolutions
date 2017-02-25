using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Application.Interfaces;

namespace TestSolutions.Application.Shippers.Queries.GetShipper
{
    public class GetShipper : IGetShipper
    {
        private readonly IDatabaseService _context;

        public GetShipper(IDatabaseService context)
        {
            _context = context;
        }

        public async Task<List<ShipperModel>> GetShippersListAsync()
        {
            return await Task<List<ShipperModel>>.Run(() => GetShipperList());
        }

        public async Task<ShipperModel> GetShipperDetailAsync(int shipperId)
        {
            return await Task<ShipperModel>.Run(() => GetShipperDetail(shipperId));
        }

        private List<ShipperModel> GetShipperList()
        {

            var shippers = _context.Shippers.Select(s => new ShipperModel
            {
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ShipperId = s.ShipperId
            });

            return shippers.ToList();
        }

        private ShipperModel GetShipperDetail(int shipperId)
        {
            var shipper = _context.Shippers
                .Where(s => s.ShipperId == shipperId)
                .Select(s => new ShipperModel
                {
                    CompanyName = s.CompanyName,
                    ContactName = s.ContactName,
                    ShipperId = s.ShipperId
                })
                .Single();
                
            return shipper;
        }

        
    }
}
