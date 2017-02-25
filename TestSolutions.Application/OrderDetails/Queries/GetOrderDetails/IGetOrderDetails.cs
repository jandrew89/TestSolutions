using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutions.Application.OrderDetails.Queries.GetOrderDetails
{
    public interface IGetOrderDetails
    {
        Task<OrderDetailsModel> ExecuteAsync(int orderId);
    }
}
