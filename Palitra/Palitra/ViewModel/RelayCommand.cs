using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Palitra.ViewModel
{
    internal class RelayCommand<T> : RelayCommand
    {
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) :
            base(execute, canExecute)
        { }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
        public RelayCommand(Action<object> _execute) : this(_execute, null) { }
   
        public RelayCommand(Action<object>_execute, Func<object, bool> _canExecute = null)
        {
            if (_execute == null)
                throw new ArgumentException("Параметр не может быть пустым");
            this.execute = _execute;
            this.canExecute = _canExecute;
        }
    }
}
