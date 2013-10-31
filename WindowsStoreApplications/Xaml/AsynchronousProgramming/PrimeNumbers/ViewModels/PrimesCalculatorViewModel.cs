namespace PrimeNumbers.ViewModels
{
    using System;
    using System.Windows.Input;
    using PrimeNumbers.Behavior;
    using PrimeNumbers.Helpers;

    public class PrimesCalculatorViewModel : ViewModelBase
    {
        private ICommand calculatePrimesCommand;

        private int rangeStart;

        public string RangeStart
        {
            get
            {
                return rangeStart.ToString();
            }
            set
            {
                try
                {
                    rangeStart = int.Parse(value);
                }
                catch (Exception)
                {
                }

                this.OnPropertyChanged("RangeStart");
            }
        }

        private int rangeEnd;

        public string RangeEnd
        {
            get
            {
                return rangeEnd.ToString();
            }
            set
            {
                rangeEnd = int.Parse(value);
                this.OnPropertyChanged("RangeEnd");
            }
        }

        private string primesResult;

        public string PrimesResult
        {
            get
            {
                return primesResult;
            }
            set
            {
                primesResult = value;
                this.OnPropertyChanged("PrimesResult");
            }
        }

        public ICommand CalculatePrimesCommand
        {
            get
            {
                if (this.calculatePrimesCommand == null)
                {
                    this.calculatePrimesCommand = new RelayCommand(this.HandleCalculatePrimesCommand);
                }

                return this.calculatePrimesCommand;
            }
        }

        private async void HandleCalculatePrimesCommand(object parameter)
        {
            var a = this.RangeStart;
            if (a == "0" && this.RangeEnd == "0")
            {
                return;
            }

            if (this.DisplayPrimes)
            {
                this.PrimesResult = string.Join(",", await PrimesNumberCalculator.GetPrimesInRangeAsync(this.rangeStart, this.rangeEnd));
            }
            else
            {
                this.PrimesResult = string.Join(",", await PrimesNumberCalculator.GetNonPrimesInRangeAsync(this.rangeStart, this.rangeEnd));
            }
        }

        private bool displayPrimes;

        public bool DisplayPrimes
        {
            get
            {
                return displayPrimes;
            }
            set
            {
                displayPrimes = value;
                this.OnPropertyChanged("DisplayPrimes");
            }
        }
    }
}