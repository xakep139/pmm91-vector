using System;
using System.Windows;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class CloseWindowCmd : Interfaces.ICommand
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
            string closeType = (parameter as string).ToLower();
            switch (closeType)
            {
                case "cur":
                    if (!WindowManager.Instance.DeleteWindow(WindowManager.Instance.ActiveIndex))
                        MessageBox.Show("Ошибка во время закрытия окна", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case "all":
                    while (WindowManager.Instance.DeleteWindow(0)) ;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
