namespace TriviaGame.Behavior
{
    using System;
    using System.Windows.Input;

    public delegate void ExecuteCommandDelegate(object obj);
    public delegate bool CanExecuteCommandDelegate(object obj);

    public class RelayCommand : ICommand
    {
        private TriviaGame.Behavior.ExecuteCommandDelegate execute;
        private TriviaGame.Behavior.CanExecuteCommandDelegate canExecute;

        public RelayCommand(TriviaGame.Behavior.ExecuteCommandDelegate execute) : this(execute, null)
        {
        }

        public RelayCommand(TriviaGame.Behavior.ExecuteCommandDelegate execute, TriviaGame.Behavior.CanExecuteCommandDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}