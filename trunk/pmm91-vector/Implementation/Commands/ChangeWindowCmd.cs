using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeWindowCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return (WindowManager.Instance.ActiveWindow != null);
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
            string changeType = (parameter as string).ToLower();
            switch (changeType)
            {
                case "next":
                    WindowManager.Instance.NextWindow();
                    break;
                case "prev":
                    WindowManager.Instance.PrevWindow();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
