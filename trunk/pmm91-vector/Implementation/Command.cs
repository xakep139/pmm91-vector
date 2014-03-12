using System;
using System.Windows;

namespace pmm91_vector
{
    class Command : System.Windows.Input.ICommand 
    {
        public pmm91_vector.Interfaces.ICommand RealCommand = null;
        public pmm91_vector.Interfaces.ICommandStack CommandStack = null;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            MessageBox.Show("Execute");
            CommandStack.DoComand(RealCommand);
        }
    }
}
