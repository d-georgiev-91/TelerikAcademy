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

namespace CountButtonClicks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clickCounts;

        public MainWindow()
        {
            InitializeComponent();
            clickCounts = 0;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            this.clickCounts++;
            this.buttonClicks.Content = this.clickCounts;
        }
    }
}
