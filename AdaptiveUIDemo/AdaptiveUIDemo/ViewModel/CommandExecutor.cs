using System;
using System.Windows.Input;

namespace AdaptiveUIDemo.ViewModel
{
    internal class CommandExecutor : ICommand
    {
        private Action<object> action;

        public CommandExecutor(Action<object> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                this.action(parameter);
            }
        }
    }
}