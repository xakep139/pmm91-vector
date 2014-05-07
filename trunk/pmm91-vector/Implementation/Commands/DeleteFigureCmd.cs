using System;
using System.Windows.Input;
using System.Collections.Generic;

using pmm91_vector.Misc;
using pmm91_vector.Implementation.Figures;

namespace pmm91_vector.Implementation.Commands
{
    public class DeleteFigureCmd : Interfaces.ICommand
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
            foreach (var figure in WindowManager.Instance.ActiveWindow.Figures.ActiveFigures)
                WindowManager.Instance.ActiveWindow.Figures.Remove(figure);
            WindowManager.Instance.ActiveWindow.Figures.ActiveFigures = new List<BaseFigure>();
            WindowManager.Instance.ActiveWindow.Graph.Paint(WindowManager.Instance.ActiveWindow.Figures);
        }
    }
}
