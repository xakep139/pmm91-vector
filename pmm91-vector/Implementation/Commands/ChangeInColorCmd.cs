using System;
using System.Linq;
using System.Windows.Input;
using WPFColorPickerLib;

using pmm91_vector.Misc;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Commands
{
    public class ChangeInColorCmd : Interfaces.ICommand
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
            var window = WindowManager.Instance.ActiveWindow;
            ColorDialog colorDialog = new ColorDialog(window.Figures.ActiveFigures.First().BoundaryColor);
            colorDialog.Owner = WindowManager.Instance.MainWindow;
            var res = colorDialog.ShowDialog();
            if (res.HasValue && res.Value)
            {
                window.Stack.DoCommand(this);
                foreach (var fig in window.Figures.ActiveFigures)
                    fig.FillBrush = new SolidColorBrush(colorDialog.SelectedColor);
                window.Graph.Paint(window.Figures);
            }
        }
    }
}
