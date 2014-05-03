using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    class ScaleFigureCmd:Interfaces.ICommand
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
            throw new NotImplementedException();
        }
    }
}
