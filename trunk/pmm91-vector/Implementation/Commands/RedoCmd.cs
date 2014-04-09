using System;

namespace pmm91_vector.Implementation.Commands
{
    public class RedoCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return CommandStack.Instance.CanRedo();
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public void Execute(object parameter)
        {
            CommandStack.Instance.RedoCommand();
        }
    }
}
