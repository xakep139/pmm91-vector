using System;

namespace pmm91_vector.Implementation.Commands
{
    public class UndoCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return (CommandStack.Instance as Interfaces.ICommandStack).CanUndo();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            (CommandStack.Instance as Interfaces.ICommandStack).UndoComand();
        }
    }
}
