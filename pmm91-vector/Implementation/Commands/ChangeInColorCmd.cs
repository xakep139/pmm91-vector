using System;
using System.Windows.Input;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeInColorCmd : Interfaces.ICommand
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
            throw new NotImplementedException();
        }
    }
}
