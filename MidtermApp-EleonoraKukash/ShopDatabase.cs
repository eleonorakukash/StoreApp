using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermApp_EleonoraKukash
{
    public class ShopDatabase
    {
        public List<Product> currentProducts;
        public Queue<Product> deletedProducts;

        public ShopDatabase()
        {
            currentProducts = new List<Product>();
            deletedProducts = new Queue<Product>();
        }

        public void AddProduct(Product product)
        {
            currentProducts.Add(product);
        }

        public void UpdateName(string name, string newName)
        {
            var selected = from product in currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            foreach (var product in selected)
                product.Name = newName.ToUpper();
        }

        public void UpdateDescription(string name, string newDescription)
        {
            var selected = from product in currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            foreach (var product in selected)
                product.Description = newDescription;
        }

        public void UpdateType(string name, string newType)
        {
            var selected = from product in currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            foreach (var product in selected)
            {
                Enum.TryParse(newType, out Product.ProductType type);
                product.Type = type;
            }
        }

        public void UpdatePrice(string name)
        {
            var selected = from product in currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            foreach (var product in selected)
            {
                if (product.Type == Product.ProductType.Books)
                {
                    product.Price = Math.Round(new Random().NextDouble() * (50 - 15) + 15, 2);
                }
                if (product.Type == Product.ProductType.Electronics)
                {
                    product.Price = Math.Round(new Random().NextDouble() * (5000 - 1500) + 1500, 2);

                }
                if (product.Type == Product.ProductType.Media)
                {
                    product.Price = Math.Round(new Random().NextDouble() * (500 - 100) + 100, 2);
                }
            }
        }

        public void UpdateSale(string name)
        {
            var selected = from product in currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            foreach (var product in selected)
            {
                if (product.Sale == true)
                    product.Sale = false;
                else
                    product.Sale = true;
            }
        }

        public void DeleteProduct(Product product)
        {
            currentProducts.Remove(product);
            deletedProducts.Append(product);
        }
    }
}
