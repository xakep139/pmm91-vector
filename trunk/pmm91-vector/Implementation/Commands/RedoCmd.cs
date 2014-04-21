using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class RedoCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (WindowManager.Instance.ActiveWindow != null)
                return WindowManager.Instance.ActiveWindow.Stack.CanRedo();
            else
                return false;
        }

        public event EventHandler CanExecuteChanged
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

        public void Execute(object parameter)
        {
            WindowManager.Instance.ActiveWindow.Stack.RedoCommand();
        }
    }
}
