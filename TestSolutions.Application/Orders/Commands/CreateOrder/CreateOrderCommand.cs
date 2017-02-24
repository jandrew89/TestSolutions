using System.Linq;
using TestSolutions.Application.Interfaces;
using TestSolutions.Application.Orders.Commands.Factory;
using TestSolutions.Common.Dates;

namespace TestSolutions.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly IDateService _dateService;
        private readonly IDatabaseService _context;
        private readonly ICreateOrderFactory _factory;

        public CreateOrderCommand(IDateService dataService, IDatabaseService context, ICreateOrderFactory factory)
        {
            this._context = context;
            this._dateService = dataService;
            this._factory = factory;
        }

        public void Execute(OrderModel model)
        {
            var date = _dateService.GetDate();

            var customer = _context.Customers.Single(c => c.CustomerId == model.CustomerId);

            var shipper = _context.Shippers.Single(s => s.ShipperId == model.ShipperId);

            var order = _factory.Create(date, customer, shipper, model.Total, model.Comments);

            _context.Orders.Add(order);
            _context.Save();

        }
    }
}
