using System;
using System.Windows.Input;

namespace thepat.Commands
{
    // a simple ICommand interface implementations

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute = null;
        private readonly Predicate<object> _canExecute = null;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
