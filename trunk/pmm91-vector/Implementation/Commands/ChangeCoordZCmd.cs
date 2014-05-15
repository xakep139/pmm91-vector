using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeCoordZCmd : Interfaces.ICommand
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
            if (parameter == null || (parameter as string) == null)
                throw new Exception("Некорректный параметр команды смены Z-координаты");
            WindowManager.Instance.ActiveWindow.Stack.DoCommand(this);

            var window = WindowManager.Instance.ActiveWindow;

            string direction = (parameter as string).ToLower();
            switch (direction)
            {
                //TODO: как должно происходить изменение Z-координаты при нескольких выделенных фигурах
                //Для 1 выделенной фигуры изменяется правильно
                case "up":
                    int minZ = window.Figures.Count;
                    foreach (var figure in window.Figures.ActiveFigures)
                    {
                        if (figure.Z < window.Figures.Count - 1)
                        {
                            if (figure.Z < minZ)
                                minZ = figure.Z;

                            int id = window.Figures.IndexOf(figure);
                            window.Figures[id].Z++;
                        }
                    }
                    foreach (var figure in window.Figures)
                    {
                        if ((figure.Z == minZ + 1) && !window.Figures.ActiveFigures.Contains(figure))
                        {
                            figure.Z--;
                            break;
                        }
                    }
                    break;
                case "down":
                    int maxZ = 0;
                    foreach (Figures.BaseFigure figure in window.Figures.ActiveFigures)
                    {
                        if (figure.Z > 0)
                        {
                            if (figure.Z > maxZ)
                                maxZ = figure.Z;

                            int id = window.Figures.IndexOf(figure);
                            window.Figures[id].Z--;
                        }
                    }
                    foreach (Figures.BaseFigure figure in window.Figures)
                    {
                        if ((figure.Z == maxZ - 1) && !window.Figures.ActiveFigures.Contains(figure))
                        {
                            figure.Z++;
                            break;
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            window.Graph.Paint(window.Figures);
        }
    }
}
