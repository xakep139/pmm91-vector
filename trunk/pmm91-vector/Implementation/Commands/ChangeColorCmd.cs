using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Input;
using WPFColorPickerLib;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeColorCmd : Interfaces.ICommand
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
                throw new Exception("Некорректный параметр команды смены цвета");
            string type = (parameter as string).ToLower();
            var window = WindowManager.Instance.ActiveWindow;

            ColorDialog colorDialog = new ColorDialog(window.Figures.ActiveFigures.First().BoundaryColor);
            colorDialog.Owner = WindowManager.Instance.MainWindow;
            var res = colorDialog.ShowDialog();
            if (res.HasValue && res.Value)
            {
                window.Stack.DoCommand(this);
                foreach (var fig in window.Figures.ActiveFigures)
                    switch (type)
                    {
                        case "in":
                            fig.FillBrush = new SolidColorBrush(colorDialog.SelectedColor);
                            break;
                        case "out":
                            fig.BoundaryColor = colorDialog.SelectedColor;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                window.Graph.Paint(window.Figures);
            }
        }
    }
}
