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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MidtermApp_EleonoraKukash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ShopDatabase database = new ShopDatabase();
        public static ShoppingCart cart = new ShoppingCart();

        public MainWindow()
        {
            InitializeComponent();
            database.currentProducts.Add(new Product("Frozen", "Collector's Edition Blu-Ray, Digital Copy", Product.ProductType.Media, false));
            database.currentProducts.Add(new Product("Coffee Maker", "Single serve", Product.ProductType.Electronics, false));
            database.currentProducts.Add(new Product("Hobbit", "J.R.R.Tolkien, Limited Edition", Product.ProductType.Books, true));
        }

        private void btnStoreWindow_Click(object sender, RoutedEventArgs e)
        {
            StoreForm storeForm = new StoreForm();
            storeForm.Owner = this;
            storeForm.Show();
        }

        private void btnManageApp_Click(object sender, RoutedEventArgs e)
        {
            ManageApplication manageApp = new ManageApplication();
            manageApp.Owner = this;
            manageApp.Show();
        }
    }
}