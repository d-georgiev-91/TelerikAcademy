namespace Calculator.ViewModels
{
    using System;
    using System.Linq;

    public class CalculatorViewModel : BaseViewModel
    {
        private string display;

        public CalculatorViewModel()
        {
            this.Display = "0";
        }

        public string Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
                this.OnPropertyChanged("Display");
            }
        }
    }
}