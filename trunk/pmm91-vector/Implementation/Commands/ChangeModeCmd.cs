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
            WindowManager.Instance.ActiveWindow.MouseDown -= GraphicWindow.GraphicWindow_MouseDown_None;
            WindowManager.Instance.ActiveWindow.MouseMove -= GraphicWindow.GraphicWindow_MouseMove_None;
            WindowManager.Instance.ActiveWindow.MouseUp -= GraphicWindow.GraphicWindow_MouseUp_None;
            WindowManager.Instance.ActiveWindow.MouseDown -= GraphicWindow.GraphicWindow_MouseDown_Ellipse;
            WindowManager.Instance.ActiveWindow.MouseMove-= GraphicWindow.GraphicWindow_MouseMove_Ellipse;
            WindowManager.Instance.ActiveWindow.MouseUp -= GraphicWindow.GraphicWindow_MouseUp_Ellipse;
            WindowManager.Instance.ActiveWindow.MouseDown -= GraphicWindow.GraphicWindow_MouseDown_Polygon;
            WindowManager.Instance.ActiveWindow.MouseMove -= GraphicWindow.GraphicWindow_MouseMove_Polygon;
            WindowManager.Instance.ActiveWindow.MouseUp -= GraphicWindow.GraphicWindow_MouseUp_Polygon;
            WindowManager.Instance.ActiveWindow.MouseDown -= GraphicWindow.GraphicWindow_MouseDown_Polyline;
            WindowManager.Instance.ActiveWindow.MouseMove -= GraphicWindow.GraphicWindow_MouseMove_Polyline;
            WindowManager.Instance.ActiveWindow.MouseUp -= GraphicWindow.GraphicWindow_MouseUp_Polyline;

            ToolMode tool;
            switch(mode)
            {
                case "none":
                    tool = ToolMode.None;
                    WindowManager.Instance.ActiveWindow.MouseDown += GraphicWindow.GraphicWindow_MouseDown_None;
                    WindowManager.Instance.ActiveWindow.MouseMove += GraphicWindow.GraphicWindow_MouseMove_None;
                    WindowManager.Instance.ActiveWindow.MouseUp += GraphicWindow.GraphicWindow_MouseUp_None;
                    break;
                case "ellipse":
                    tool = ToolMode.Ellipse;
                    WindowManager.Instance.ActiveWindow.MouseDown += GraphicWindow.GraphicWindow_MouseDown_Ellipse;
                    WindowManager.Instance.ActiveWindow.MouseMove += GraphicWindow.GraphicWindow_MouseMove_Ellipse;
                    WindowManager.Instance.ActiveWindow.MouseUp += GraphicWindow.GraphicWindow_MouseUp_Ellipse;
                    break;
                case "polygon":
                    tool = ToolMode.Polygon;
                    WindowManager.Instance.ActiveWindow.MouseDown += GraphicWindow.GraphicWindow_MouseDown_Polygon;
                    
                    WindowManager.Instance.ActiveWindow.MouseMove += GraphicWindow.GraphicWindow_MouseMove_Polygon;
                    WindowManager.Instance.ActiveWindow.MouseUp += GraphicWindow.GraphicWindow_MouseUp_Polygon;
                    break;
                case "polyline":
                    tool = ToolMode.Polyline;
                    WindowManager.Instance.ActiveWindow.MouseDown += GraphicWindow.GraphicWindow_MouseDown_Polyline;
                    WindowManager.Instance.ActiveWindow.MouseMove += GraphicWindow.GraphicWindow_MouseMove_Polyline;
                    WindowManager.Instance.ActiveWindow.MouseUp += GraphicWindow.GraphicWindow_MouseUp_Polyline;
                    break;
                default:
                    throw new NotImplementedException();
            }
            WindowManager.Instance.ActiveWindow.Mode = tool;
        }
    }
}
