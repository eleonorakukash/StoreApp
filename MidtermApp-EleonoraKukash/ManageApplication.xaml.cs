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
    /// Interaction logic for ManageApplication.xaml
    /// </summary>
    public partial class ManageApplication : Window
    {
        public ManageApplication()
        {
            InitializeComponent();
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void lstDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var productsList = from item in MainWindow.database.currentProducts
                               where lstDatabase.SelectedItem == item
                               select item;
            foreach (var product in productsList)
            {
                tbName.Text = product.Name;
                tbDescription.Text = product.Description;
                cmbType.Text = product.Type.ToString();
                lblPrice.Content = product.Price.ToString();
                if (product.Sale)
                    chkSale.IsChecked = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool failed = false;
            if ((tbName.Text == "") || (tbDescription.Text == "") || (cmbType.SelectedItem == null))
                MessageBox.Show("One or more required fields are empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                foreach (var product in MainWindow.database.currentProducts)
                {
                    if (product.Name == tbName.Text.ToUpper())
                    {
                        MessageBox.Show("The product already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        failed = true;
                        break;
                    }
                }
                if (!failed)
                {
                    string name = tbName.Text;
                    string description = tbDescription.Text;
                    Product.ProductType type = Product.ProductType.Media;
                    if (cmbType.Text == "Electronics")
                        type = Product.ProductType.Electronics;
                    if (cmbType.Text == "Books")
                        type = Product.ProductType.Books;
                    bool sale = false;
                    if (chkSale.IsChecked == true)
                        sale = true;
                    Product newItem = new Product(name, description, type, sale);
                    MainWindow.database.AddProduct(newItem);
                }
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var products = from item in MainWindow.database.currentProducts
                           where lstDatabase.SelectedItem == item
                           select item;
            foreach (var item in products)
            {
                MainWindow.database.currentProducts.Remove(item);
                break;
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            var products = from item in MainWindow.database.currentProducts
                           where lstDatabase.SelectedItem == item
                           select item;
            foreach (var item in products)
            {
                MainWindow.database.UpdateName(item.Name, tbName.Text);
                tbName.Text = item.Name.ToString();
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void btnDescription_Click(object sender, RoutedEventArgs e)
        {
            var products = from item in MainWindow.database.currentProducts
                           where lstDatabase.SelectedItem == item
                           select item;
            foreach (var item in products)
            {
                MainWindow.database.UpdateDescription(item.Name, tbDescription.Text);
                tbDescription.Text = item.Description.ToString();
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void btnType_Click(object sender, RoutedEventArgs e)
        {
            var products = from item in MainWindow.database.currentProducts
                           where lstDatabase.SelectedItem == item
                           select item;
            foreach (var item in products)
            {
                MainWindow.database.UpdateType(item.Name, cmbType.Text);
                cmbType.Text = item.Type.ToString();
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void btnPrice_Click(object sender, RoutedEventArgs e)
        {
            var products = from item in MainWindow.database.currentProducts
                               where lstDatabase.SelectedItem == item
                               select item;
            foreach (var item in products)
            {
                MainWindow.database.UpdatePrice(item.Name);
                lblPrice.Content = item.Price.ToString(); 
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            var products = from item in MainWindow.database.currentProducts
                           where lstDatabase.SelectedItem == item
                           select item;
            foreach (var item in products)
            {
                MainWindow.database.UpdateSale(item.Name);
                chkSale.IsChecked = item.Sale;
            }
            var productsList = from item in MainWindow.database.currentProducts
                               select item;
            lstDatabase.DataContext = productsList;
        }
    }
}
