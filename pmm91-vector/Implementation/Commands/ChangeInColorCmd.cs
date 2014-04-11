using System;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeInColorCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            //TODO: сделать команду активной, только если выбрана некоторая фигура
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
