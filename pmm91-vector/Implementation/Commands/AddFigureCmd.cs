using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmm91_vector.Implementation.Commands
{
    public class AddFigure : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            CommandStack.Instance.DoComand(this);
            string figure = parameter as string;
            switch(figure)
            {
                case "Ellipse":
                case "ellipse":

                    //Написать реальную добавку

                    break;
                default:
                    break;
            }
            App.Current.Shutdown(0);
        }

    }
}
