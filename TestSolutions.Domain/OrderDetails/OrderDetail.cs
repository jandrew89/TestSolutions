using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Common;
using TestSolutions.Domain.Orders;
using TestSolutions.Domain.Products;

namespace TestSolutions.Domain.OrderDetails
{
    public class OrderDetail : IEntity
    {
        private int _quantity;
        private decimal _unitPrice;
        private decimal _total;


        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }



        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;
                UpdateTotalPrice();
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                UpdateTotalPrice();
            }
        }
        public decimal Total
        {
            get { return _total; }
            private set
            {
                _total = value;
            }
        }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


        private void UpdateTotalPrice()
        {
            _total = _unitPrice * _quantity;
        }
    }
}
