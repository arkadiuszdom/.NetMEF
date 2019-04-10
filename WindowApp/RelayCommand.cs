using System;
using System.Windows.Input;

namespace WindowApp
{
    public class RelayCommand : ICommand
    {
        Action action;
        bool canExecute;
        Action<object> parameterizedAction;

        public RelayCommand(Action action, bool canExecute = true)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> parameterizedAction, bool canExecute = true)
        {

            this.parameterizedAction = parameterizedAction;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            parameterizedAction(parameter);
        }
    }
}
