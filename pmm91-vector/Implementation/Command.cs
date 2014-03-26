using System;
using System.Windows;

namespace pmm91_vector
{
    class Command : System.Windows.Input.ICommand 
    {
        public Interfaces.ICommand RealCommand = null;
        public Interfaces.ICommandStack RealCommandStack = new Implementation.CommandStack();

        public bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Exit":
                    return true;
                case "Undo":
                    return RealCommandStack.CanUndo();
                case "Redo":
                    return RealCommandStack.CanRedo();
                default:
                    throw new ResourceReferenceKeyNotFoundException();
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Exit":
                    App.Current.Shutdown(0);
                    break;
                case "Undo":
                    RealCommandStack.UndoComand();
                    break;
                case "Redo":
                    RealCommandStack.RedoComand();
                    break;
                case "someRealCommand":                     //////////////////////////////////////Вставить настоящие коды команд
                    RealCommandStack.DoComand(RealCommand);
                    break;
                default:
                    throw new Exception("Неизвестный код команды");
            }
        }
    }
}
