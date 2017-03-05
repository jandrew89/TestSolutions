using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task ExecuteAsync(OrderModel model)
        {
            await Task.Run(() => Execute(model));
        }

        private void Execute(OrderModel model)
        {
            var date = _dateService.GetDate();

            var customer = _context.Customers.Single(c => c.CustomerId == model.CustomerId);

            var shipper = _context.Shippers.Single(s => s.ShipperId == model.ShipperId);

            var employee = _context.Employees.Single(e => e.EmployeeId == model.EmployeeId);

            var order = _factory.Create(date, employee, customer, shipper, model.Total, model.Comments);

            _context.Orders.Add(order);
            _context.Save();

        }

        
    }
}
