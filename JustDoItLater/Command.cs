using System;
using System.Windows.Input;

namespace JustDoItLater
{
    internal class Command : ICommand
    {
        private Action _Execute;

        public Command(Action execute)
        {
            _Execute = execute;
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
            _Execute.Invoke();
        }
    }
}