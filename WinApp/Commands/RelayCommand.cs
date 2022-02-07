using DomainModel;
using System;
using System.Windows.Input;
using WinApp.PropertyChanged;

namespace WinApp.Commands
{
    [Notify]
    public class RelayCommand : PropertyChangedBase, ICommand
    {
        private readonly Action<object> _execute;
        public Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException("Execute action cannot be null");
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecuteNull
        {
            get
            {
                return CanExecute(null);
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
                RaisePropertyChanged("CanExecuteNull");
            }
        }
    }
}
