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
    /// Interaction logic for ShoppingCartWindow.xaml
    /// </summary>
    public partial class ShoppingCartWindow : Window
    {
        public ShoppingCartWindow()
        {
            InitializeComponent();
            var productsList = from item in MainWindow.cart.shoppingCart
                               select item;
            lstCart.DataContext = productsList;
            tbTotal.Text = MainWindow.cart.TotalPurchase.ToString();
        }

        private void lstCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productsList = from item in MainWindow.cart.shoppingCart
                               where lstCart.SelectedItem == item
                               select item;
            foreach (var product in productsList)
                tbCost.Text = product.TotalCost.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
