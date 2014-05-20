using System;
using System.Windows.Input;

using pmm91_vector.Misc;
using System.Collections;

namespace pmm91_vector.Implementation.Commands
{
    class MoveFigureCmd : Interfaces.ICommand
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
            //TODO Исправить на что-нибудь нормальное, как будет реализован Move
            var parameters = parameter as ArrayList;
            System.Windows.Point[] p = parameters[0] as System.Windows.Point[];
            
            var window = WindowManager.Instance.ActiveWindow;
            window.Stack.DoCommand(this);
            
            FigureTransform ft = new FigureTransform();
            ft.Move(p[0]);
            foreach (Figures.BaseFigure figure in window.Figures.ActiveFigures)
            {
                figure.Transform(ft);
            }
            window.Graph.Paint(window.Figures);
        }
    }
}
