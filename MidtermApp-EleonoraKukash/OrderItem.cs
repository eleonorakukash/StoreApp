using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermApp_EleonoraKukash
{
    public class OrderItem
    {
        private Product _product;
        private int _quantity;
        private double _totalCost;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public double TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        public OrderItem(Product product, int quantity, double totalCost)
        {
            Product = product;
            Quantity = quantity;
            TotalCost = totalCost;
        }

        public override string ToString()
        {
            string result = "";
            if (Product.Sale)
                result = $"{Product.Name} ({Product.Price}, {Quantity}, on sale)";
            else
                result = $"{Product.Name} ({Product.Price}, {Quantity})";
            return result;
        }
    }
}