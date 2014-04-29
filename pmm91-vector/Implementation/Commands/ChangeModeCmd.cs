using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    class ChangeModeCmd:Interfaces.ICommand
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
                case "ellipse":
                    tool=ToolMode.Ellipse;
                    break;
                case "polygon":
                    tool=ToolMode.Polygon;
                    break;
                case "polyline":
                    tool=ToolMode.Polyline;
                    break;
                default:
                    tool=ToolMode.None;
                    break;
            }
            WindowManager.Instance.ActiveWindow.Mode = tool;
        }
    }
}
