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

namespace SimpleTextResizer
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

        public void SetToLarger(object sender, RoutedEventArgs e)
        {
            double resizedValue = this.SliderTextResizer.Value * 2;

            if (resizedValue >= this.SliderTextResizer.Maximum)
            {
                this.SliderTextResizer.Value = this.SliderTextResizer.Maximum;
            }
            else
            {
                this.SliderTextResizer.Value = resizedValue;
            }
        }

        private void SetToSmaller(object sender, RoutedEventArgs e)
        {
            double resizedValue = this.SliderTextResizer.Value / 2;

            if (resizedValue <= this.SliderTextResizer.Minimum)
            {
                this.SliderTextResizer.Value = this.SliderTextResizer.Minimum;
            }
            else
            {
                this.SliderTextResizer.Value = resizedValue;
            }
        }
    }
}
