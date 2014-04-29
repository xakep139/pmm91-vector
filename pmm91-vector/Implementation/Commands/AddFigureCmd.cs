using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections;
using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class AddFigureCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return (WindowManager.Instance.ActiveWindow != null);
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
            WindowManager.Instance.ActiveWindow.Stack.DoCommand(this);
            Figures.BaseFigure newFigure = null;
            ArrayList ar = parameter as ArrayList;
            Point[] points = ar[0] as Point[];
            //TODO: выставить необходимые координаты
            Point[] figCoords = points;


            // string figureType = (parameter as string).ToLower();
            switch (WindowManager.Instance.ActiveWindow.Mode)
            {
                case ToolMode.Ellipse:
                    newFigure = new Figures.Ellipse(figCoords);
                    break;
                case ToolMode.Polygon:
                    newFigure = new Figures.Polygon(figCoords[0], figCoords[1]);
                    break;
                case ToolMode.Polyline:
                    newFigure = new Figures.Polyline(figCoords);
                    break;
                default:
                    break;
            }
            try
            {
                newFigure.BoundaryColor = Colors.Black;
                WindowManager.Instance.ActiveWindow.Figures.Add(newFigure);
                newFigure.Draw(WindowManager.Instance.ActiveWindow.Graph);
            }
            catch { }
        }
    }
}
