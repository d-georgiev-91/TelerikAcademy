namespace Calculator.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows.Input;
    using Calculator.Behavior;

    public class CalculatorViewModel : BaseViewModel
    {
        private const string DefaultCalculatorDisplayValue = "0";

        private string display;

        private double currentNumber;

        private double? leftArgument;
        private double? rightArgument;

        private MathOperation? lastMathOperation;

        public CalculatorViewModel()
        {
            this.Display = DefaultCalculatorDisplayValue;
            this.leftArgument = null;
            this.rightArgument = null;
        }

        private ICommand clearEntryCommand;

        public ICommand ClearEntryCommand
        {
            get
            {
                if (this.clearEntryCommand == null)
                {
                    this.clearEntryCommand = new RelayCommand(this.HandleClearEntryCommand);
                }

                return this.clearEntryCommand;
            }
        }

        private void HandleClearEntryCommand(object parameter)
        {
            this.Display = DefaultCalculatorDisplayValue;
        }

        private ICommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(this.HandleDeleteCommand);
                }

                return this.deleteCommand;
            }
        }

        private void HandleDeleteCommand(object parameter)
        {
            if (this.Display.Length == 1)
            {
                this.Display = DefaultCalculatorDisplayValue;
            }
            else
            {
                this.Display = this.Display.Substring(0, this.Display.Length - 1);
            }
        }

        private ICommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (this.clearCommand == null)
                {
                    this.clearCommand = new RelayCommand(this.HandleClearCommand);
                }

                return this.clearCommand;
            }
        }

        private void HandleClearCommand(object parameter)
        {
            this.lastMathOperation = null;
            this.Display = DefaultCalculatorDisplayValue;
            this.leftArgument = null;
            this.rightArgument = null;
        }

        private ICommand enterNumberCommand;

        public ICommand EnterNumberCommand
        {
            get
            {
                if (this.enterNumberCommand == null)
                {
                    this.enterNumberCommand = new RelayCommand(this.HandleEnterNumberCommand);
                }

                return this.enterNumberCommand;
            }
        }

        private void HandleEnterNumberCommand(object parameter)
        {
            string currentInput = parameter as string;

            if (currentInput == null)
            {
                throw new ArgumentException("Invalid input");
            }

            this.Display += currentInput;

            if (this.leftArgument == null)
            {
                this.leftArgument = this.currentNumber;
            }
            else
            {
                this.rightArgument = this.currentNumber;
            }
        }

        private ICommand doMathOperationCommand;

        public ICommand DoMathOperationCommand
        {
            get
            {
                if (this.doMathOperationCommand == null)
                {
                    this.doMathOperationCommand = new RelayCommand(this.HandleDoMathOperationMyCommand);
                }

                return this.doMathOperationCommand;
            }
        }

        private void HandleDoMathOperationMyCommand(object parameter)
        {
            string mathOperation = parameter as string;

            switch (mathOperation)
            {
                case "+":
                    ProcessAddition();
                    this.Display = DefaultCalculatorDisplayValue;
                    break;
                case "-":
                    ProcessSubstraction();
                    break;
                case "*":
                    ProcessMultiplication();
                    break;
                case "/":
                    ProcessDivision();
                    break;
                case "√":
                    ProcessSquareRoot();
                    break;
                case "=":
                    ProcessEqual();
                    break;
                case "1/x":
                    ProcessReciprocal();
                    break;
                default:
                    break;
            }
        }

        private void ProcessReciprocal()
        {
            double result = 1 / this.currentNumber;
            this.Display = result.ToString();
        }

        private void ProcessEqual()
        {
            this.ExecuteMathOperationIfExists();
        }

        private void ProcessSquareRoot()
        {
            double result = Math.Sqrt(this.currentNumber);
            this.Display = result.ToString();
        }

        private void ProcessDivision()
        {
            this.ExecuteMathOperationIfExists();
            this.lastMathOperation = MathOperation.Division;
        }

        private void ProcessMultiplication()
        {
            this.ExecuteMathOperationIfExists();
            this.lastMathOperation = MathOperation.Multiplication;
        }

        private void ProcessSubstraction()
        {
            this.ExecuteMathOperationIfExists();
            this.lastMathOperation = MathOperation.Substraction;
        }

        private void ProcessAddition()
        {
            this.ExecuteMathOperationIfExists();
            this.lastMathOperation = MathOperation.Addition;    
        }

        private void ExecuteMathOperationIfExists()
        {
            if (this.lastMathOperation == null || this.leftArgument == null)
            {
                return;
            }

            double? result;

            switch (this.lastMathOperation)
            {
                case MathOperation.Addition:
                    result = this.ExecuteAddition();
                    break;
                case MathOperation.Substraction:
                    result = this.ExecuteSubstraction();
                    break;
                case MathOperation.Multiplication:
                    result = this.ExecuteMultiplication();
                    break;
                case MathOperation.Division:
                    result = this.ExecuteDivision();
                    break;
                default:
                    return;
            }

            this.Display = result.ToString();
            this.lastMathOperation = null;
        }
  
        private double? ExecuteDivision()
        {
            if (this.rightArgument == 0)
            {
                throw new InvalidOperationException("Zero division");
            }

            double? result = this.leftArgument / this.rightArgument;
            
            return result;
        }
  
        private double? ExecuteMultiplication()
        {
            double? result = this.leftArgument * this.rightArgument;

            return result;
        }
  
        private double? ExecuteSubstraction()
        {
            double? result = this.leftArgument - this.rightArgument;

            return result;
        }
  
        private double? ExecuteAddition()
        {
            double? result = this.leftArgument + this.rightArgument;
            
            return result;
        }

        public string Display
        {
            get
            {
                return this.display;
            }
            set
            {
                if (value[0] == '0' && value.Length > 1)
                {
                    this.display = value.Substring(1);
                }
                else
                {
                    this.display = value;
                }

                this.currentNumber = double.Parse(this.display);
                this.OnPropertyChanged("Display");
            }
        }
    }
}