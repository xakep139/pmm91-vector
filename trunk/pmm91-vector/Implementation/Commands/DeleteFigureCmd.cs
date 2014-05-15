using System;
using System.Windows.Input;

using pmm91_vector.Misc;

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
            int count = window.Figures.ActiveFigures.Count; //Число удаляемых фигур
            foreach (var delFig in window.Figures.ActiveFigures)
            {
                window.Figures.Remove(delFig);
                //Пересчёт Z-координаты:
                foreach (var restFig in window.Figures)
                    if (restFig.Z > delFig.Z)
                        restFig.Z--;
            }
            window.Figures.ActiveFigures.Clear();
            window.Graph.Paint(window.Figures);
        }
    }
}
