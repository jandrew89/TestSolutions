using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Application.Orders.Commands.CreateOrder
{
    public interface ICreateOrderCommand
    {
        void Execute(OrderModel model);
    }
}
