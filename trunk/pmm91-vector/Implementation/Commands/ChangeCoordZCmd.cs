using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    class ChangeCoordZCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            //TODO: сделать команду активной, только если выбрана некоторая фигура
            return true;
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
