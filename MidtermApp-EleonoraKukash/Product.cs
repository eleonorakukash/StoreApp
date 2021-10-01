using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermApp_EleonoraKukash
{
    public class Product
    {
        private string _name;
        private string _description;
        private ProductType _type;
        private double _price;
        private bool _sale;

        public enum ProductType
        {
            Books,
            Electronics,
            Media
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ProductType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Price
        {
            get { return _price; }
            set {_price = value; }
        }

        public bool Sale
        {
            get { return _sale; }
            set { _sale = value; }
        }

        public Product(string name, string description, ProductType type, bool sale)
        {
            Name = name.ToUpper();
            Description = description;
            Type = type;
            if (Type == ProductType.Books)
            {
                Price = Math.Round(new Random().NextDouble() * (50 - 15) + 15, 2);
            }
            if (Type == ProductType.Electronics)
            {
                Price = Math.Round(new Random().NextDouble() * (5000 - 1500) + 1500, 2);

            }
            if (Type == ProductType.Media)
            {
                Price = Math.Round(new Random().NextDouble() * (500 - 100) + 100, 2);
            }
            Sale = sale;
        }
        
        public override string ToString()
        {
            string result = "";
            if (Sale)
                result = $"{Name}: {Description}, type {Type}, price ${Price}, on sale";
            else
                result = $"{Name}: {Description}, type {Type}, price ${Price}";
            return result;
        }
    }
}