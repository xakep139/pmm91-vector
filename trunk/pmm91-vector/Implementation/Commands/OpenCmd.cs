using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

using pmm91_vector.Misc;
using pmm91_vector.Streamers;

namespace pmm91_vector.Implementation.Commands
{
    public class OpenCmd : Interfaces.ICommand
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Бинарные файлы (*.bin)|*.bin|XML файлы (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = openFileDialog.FileName;
                var newWindow = WindowManager.Instance.NewWindow();
                //В зависимости от типа файла создаём Streamer'а (наследника BaseStream)
                //и вызываем метод FigureCollection.Load(BaseStream stream)
                //и записываем path в свойство FigureCollection.FileName
                try
                {
                    if (openFileDialog.FilterIndex == 1)
                        using (var stream = new BinaryFileStream(path))
                            newWindow.Figures.Load(stream);
                    else
                        using (var stream = new XmlFileStream(path))
                            newWindow.Figures.Load(stream);
                    newWindow.Figures.FileName = path;
                    //Вызываем отрисовку:
                    newWindow.Graph.Paint(newWindow.Figures);
                }
                catch (Exception e)
                {
                    WindowManager.Instance.DeleteWindow(WindowManager.Instance.ActiveIndex);
                    MessageBox.Show(e.Message + ":" + Environment.NewLine + e.InnerException,
                        "Ошибка открытия", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
