using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MidtermApp_EleonoraKukash
{
    /// <summary>
    /// Interaction logic for StoreForm.xaml
    /// </summary>
    public partial class StoreForm : Window
    {
        public StoreForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string name = tbProduct.Text;
            var selected = from product in MainWindow.database.currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            if (selected.Any())
            {
                foreach (var product in selected)
                {
                    tbDescription.Text = product.Description;
                    cmbType.Text = product.Type.ToString();
                    tbPrice.Text = product.Price.ToString();
                    if (product.Sale)
                        chkSale.IsChecked = true;            
                }
            }
            else
                MessageBox.Show("Product not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            double cost = 0;
            int quantity = 0;
            string name = tbProduct.Text;
            var selected = from product in MainWindow.database.currentProducts
                           where product.Name == name.ToUpper()
                           select product;
            if (selected.Any())
            {
                foreach (var product in selected)
                {
                    if ((rdoQuantity.IsChecked == false) && (rdoTotal.IsChecked == false))
                    {
                        MessageBox.Show("Select if it is quantity or amount", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        try
                        {
                            if (rdoQuantity.IsChecked == true)
                            {
                                quantity = int.Parse(tbOrder.Text);
                                cost = quantity * product.Price;
                                if (product.Sale)
                                    cost *= 0.75;
                            }
                            else
                            {
                                cost = double.Parse(tbOrder.Text);
                                if (product.Sale)
                                {
                                    quantity = (int)(cost / (product.Price * 0.75));
                                    cost = quantity * product.Price;
                                }
                                else
                                {
                                    quantity = (int)(cost / product.Price);
                                    cost = quantity * product.Price;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid value or no values entered", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                            
                        }
                        OrderItem order = new OrderItem(product, quantity, cost);
                        MainWindow.cart.AddToCart(order);
                    }
                }
            }
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow();
            shoppingCartWindow.Owner = this;
            shoppingCartWindow.Show();
        }
    }
}