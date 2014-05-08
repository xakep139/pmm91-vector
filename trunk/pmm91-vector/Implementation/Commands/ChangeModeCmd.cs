using System;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeModeCmd : Interfaces.ICommand
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
            string mode = (parameter as string).ToLower();
            ToolMode tool;
            switch(mode)
            {
                case "none":
                    tool = ToolMode.Select;
                    break;
                case "ellipse":
                    tool = ToolMode.Ellipse;
                    break;
                case "polygon":
                    tool = ToolMode.Polygon;
                    break;
                case "polyline":
                    tool = ToolMode.Polyline;
                    break;
                case "move":
                    tool = ToolMode.Move;
                    break;
                case "scale":
                    tool = ToolMode.Scale;
                    break;
                default:
                    throw new NotImplementedException();
            }
            WindowManager.Instance.ActiveWindow.Mode = tool;
        }
    }
}
