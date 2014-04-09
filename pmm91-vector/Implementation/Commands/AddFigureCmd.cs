using System;

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
                    break;
                case "polyline":
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
