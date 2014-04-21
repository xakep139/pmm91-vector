using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
            //TODO: выставить необходимые координаты
            Point[] figCoords = new Point[] { new Point(110, 150), new Point(180, 240), new Point(210, 170) };
            string figureType = (parameter as string).ToLower();
            switch(figureType)
            {
                case "ellipse":
                    newFigure = new Figures.Ellipse(figCoords);
                    break;
                case "polygon":
                    newFigure = new Figures.Polygon(figCoords[0], figCoords[1]);
                    break;
                case "polyline":
                    newFigure = new Figures.Polyline(figCoords);
                    break;
                default:
                    throw new NotImplementedException();
            }
            newFigure.BoundaryColor = Colors.Black;
            WindowManager.Instance.ActiveWindow.Figures.Add(newFigure);
            newFigure.Draw(WindowManager.Instance.ActiveWindow.Graph);
        }
    }
}
