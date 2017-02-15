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


        public void Execute(OrderModel model)
        {
            
        }
    }
}
