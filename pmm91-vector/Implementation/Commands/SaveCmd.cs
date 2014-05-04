using System;
using System.Windows;
using System.Windows.Input;

using pmm91_vector.Misc;
using pmm91_vector.Streamers;

namespace pmm91_vector.Implementation.Commands
{
    public class SaveCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return (WindowManager.Instance.ActiveWindow != null &&
                    WindowManager.Instance.ActiveWindow.Figures.FileName != null &&
                    WindowManager.Instance.ActiveWindow.Figures.FileName != "");
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
            //В зависимости от типа файла создаём Streamer'а (наследника BaseStream)
            //и вызываем метод FigureCollection.Save(BaseStream stream)
            //и записываем path в свойство FigureCollection.FileName
            string path = WindowManager.Instance.ActiveWindow.Figures.FileName;
            try
            {
                if (path.EndsWith(".bin"))
                    using (var stream = new BinaryFileStream(path))
                        WindowManager.Instance.ActiveWindow.Figures.Save(stream);
                else
                    using (var stream = new XmlFileStream(path))
                        WindowManager.Instance.ActiveWindow.Figures.Save(stream);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ":" + Environment.NewLine + e.InnerException,
                    "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
