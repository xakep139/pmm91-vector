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
            string IsTrueCommand = parameters[1] as string;
            if (IsTrueCommand != "")
                WindowManager.Instance.ActiveWindow.Stack.DoCommand(this);
            FigureTransform ft = new FigureTransform();
            ft.Move(p[0]);
        }
    }
}
