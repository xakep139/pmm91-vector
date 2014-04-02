using System;

namespace pmm91_vector.Implementation.Commands
{
    public class ExitCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            App.Current.Shutdown(0);
        }

    }
}
