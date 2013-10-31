namespace Calculator.Behavior
{
    using System;
    using System.Linq;
    using System.Windows.Input;

    public delegate bool CanExecuteCommandDelegate(object parameter);

    public delegate void ExecuteCommandDelegate(object parameter);
    public class RelayCommand : ICommand
    {
        private CanExecuteCommandDelegate canExecute;
        private ExecuteCommandDelegate execute;
        public RelayCommand(ExecuteCommandDelegate execute) : this(execute, null)
        {
            
        }

        public RelayCommand(ExecuteCommandDelegate execute, CanExecuteCommandDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute != null)
            {
                return this.canExecute(parameter);
            }

            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}