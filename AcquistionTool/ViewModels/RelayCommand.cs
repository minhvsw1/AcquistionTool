using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcquistionTool.ViewModels
{
    public class RelayCommand<T> : ICommand
    {
        Action<T> _execute;
        Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
              CommandManager.RequerySuggested += value;
            }

            remove
            {
              CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return _canExecute == null?true : _canExecute((T)parameter);
        }

        void ICommand.Execute(object? parameter)
        {
           _execute((T)parameter);
        }
    }
}
