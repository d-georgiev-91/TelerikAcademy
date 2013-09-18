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

namespace Calculator
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
        public void OnClickDoMathOperation(object sender, RoutedEventArgs e)
        {
            string buttonOperand = (sender as Button).Content.ToString();

            switch (buttonOperand)
            {
                case "+":
                    Add();
                    break;
                case "-":
                    Substract();
                    break;
                case "√":
                    Sqrt();
                    break;
                default:
                    break;
            }
        }

        private void Substract()
        {
            throw new NotImplementedException();
        }

        private void Sqrt()
        {
            double number = double.Parse(this.TextBoxNumbersContext.Text);
            double result = Math.Sqrt(number);
            this.TextBoxNumbersContext.Text = result.ToString();
        }

        private void Add()
        {
            lastNumberInBuffer = double.Parse(this.TextBoxNumbersContext.Text);
        }

        public void OnClickChangeSign(object sender, RoutedEventArgs e)
        {
            var currentNumber = double.Parse(this.TextBoxNumbersContext.Text);
            currentNumber *= -1;
            this.TextBoxNumbersContext.Text = currentNumber.ToString();
        }

        public void OnClickClearContainer(object sender, RoutedEventArgs e)
        {
            this.TextBoxNumbersContext.Text = "0";
        }

        public void OnButtonClickEnterNumber(object sender, RoutedEventArgs e)
        {
            var number = (sender as Button).Content.ToString();

            if (this.TextBoxNumbersContext.Text == "0")
            {
                if (number == "0")
                {
                    return;    
                }

                this.TextBoxNumbersContext.Text = number;
            }
            else 
            {
                this.TextBoxNumbersContext.Text += number;
            }
        }

        public void OnButtonClickDelete(object sender, RoutedEventArgs e)
        {
            if (this.TextBoxNumbersContext.Text.Length > 1)
            {
                this.TextBoxNumbersContext.Text = this.TextBoxNumbersContext.Text.Substring(0, this.TextBoxNumbersContext.Text.Length - 1);
            }
            else
            {
                this.TextBoxNumbersContext.Text = "0";
            }
        }

        public double lastNumberInBuffer { get; set; }
    }
}
