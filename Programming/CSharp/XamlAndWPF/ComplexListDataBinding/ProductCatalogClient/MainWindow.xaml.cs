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

namespace ProductCatalogClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OnClickGetProduct(object sender, RoutedEventArgs e)
        {
            int productId;

            try
            {
                productId = int.Parse(this.TextBoxProductId.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(string.Format("Invalid product id!\nProduct id should be a number!"));
                return;
            }

            var product = ProductsViewModels.ProductViewModel.GetProduct(productId);

            if (product != null)
            {
                this.DataContext = product;
            }
            else
            {
                MessageBox.Show(string.Format("No product was found with Id: {0}", productId));
            }
        }
    }
}
