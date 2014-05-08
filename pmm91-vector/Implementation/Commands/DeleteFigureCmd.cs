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
            var window = WindowManager.Instance.ActiveWindow;
            window.Stack.DoCommand(this);
            foreach (var figure in window.Figures.ActiveFigures)
                window.Figures.Remove(figure);
            window.Figures.ActiveFigures.Clear();
            window.Graph.Paint(window.Figures);
        }
    }
}
