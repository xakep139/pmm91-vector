using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeCoordZCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return (WindowManager.Instance.ActiveWindow != null &&
                    WindowManager.Instance.ActiveWindow.Figures.ActiveFigures.Count > 0);
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
            if (parameter == null || (parameter as string) == null)
                throw new Exception("Некорректный параметр команды смены Z-координаты");
            WindowManager.Instance.ActiveWindow.Stack.DoCommand(this);
            string direction = (parameter as string).ToLower();
            switch (direction)
            {
                //TODO: написать реальное изменение Z-координаты
                case "up":
                    break;
                case "down":
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
