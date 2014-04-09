using System;

namespace pmm91_vector.Implementation.Commands
{
    public class ExitCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public void Execute(object parameter)
        {
            App.Current.Shutdown(0);
        }

    }
}
