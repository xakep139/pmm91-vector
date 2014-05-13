using System;
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
            Point[] figCoords = parameter as Point[];
            if (parameter == null || figCoords == null)
                throw new Exception("Некорректный параметр команды добавления фигуры");
            var window = WindowManager.Instance.ActiveWindow;
            window.Stack.DoCommand(this);
            Figures.BaseFigure newFigure = null;
            switch (window.Mode)
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
                    throw new NotImplementedException();
            }
            try
            {
                newFigure.BoundaryColor = Colors.Black;
                newFigure.Z = window.Figures.Count;
                window.Figures.ActiveFigures.Clear();
                window.Figures.Add(newFigure);
                window.Graph.Paint(window.Figures);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении фигуры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
