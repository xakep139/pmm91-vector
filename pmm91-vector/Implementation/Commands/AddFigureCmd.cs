using System;
using System.Windows;
using System.Windows.Input;

namespace pmm91_vector.Implementation.Commands
{
    public class AddFigureCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
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
            CommandStack.Instance.DoCommand(this);
            string figure = (parameter as string).ToLower();
            switch(figure)
            {
                //TODO: написать реальное добавление
                case "ellipse":
                    break;
                case "polygon":
                    //Как можно добавить прямоугольник:
                    //TODO: выставить необходимые координаты
                    ((MainWindow)App.Current.MainWindow).figures.Add(new Figures.Polygon(new Point(150.0, 150.0), new Point(220.0, 220.0)));
                    //И так тоже делать не следует:
                    ((MainWindow)App.Current.MainWindow).graphics.Paint(((MainWindow)App.Current.MainWindow).figures);
                    break;
                case "polyline":
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
