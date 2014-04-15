using System;
using System.Windows;

namespace pmm91_vector.Implementation.Commands
{
    public class AddFigureCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

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
                    Figures.Polygon polygon = new Figures.Polygon(new System.Windows.Point(150.0, 150.0), new System.Windows.Point(220.0, 220.0));
                    ((MainWindow)App.Current.MainWindow).figures.Add(polygon);
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
