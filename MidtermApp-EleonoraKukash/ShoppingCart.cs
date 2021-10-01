using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermApp_EleonoraKukash
{
    public class ShoppingCart
    {
        public Stack<OrderItem> shoppingCart;
        public double _totalPurchase;


        public double TotalPurchase
        {
            get { return _totalPurchase; }
            set { _totalPurchase = value; }
        }

        public ShoppingCart()
        {
            shoppingCart = new Stack<OrderItem>();
            TotalPurchase = 0;
        }

        public void AddToCart(OrderItem orderItem)
        {
            shoppingCart.Push(orderItem);
            TotalPurchase += orderItem.TotalCost;
        }
    }
}