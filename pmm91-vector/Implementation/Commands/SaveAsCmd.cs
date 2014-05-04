using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

using pmm91_vector.Misc;
using pmm91_vector.Streamers;

namespace pmm91_vector.Implementation.Commands
{
    public class SaveAsCmd : Interfaces.ICommand
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Бинарный файл (*.bin)|*.bin|XML-файл (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;

            var result = saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = saveFileDialog.FileName;
                //В зависимости от типа файла создаём Streamer'а (наследника BaseStream)
                //и вызываем метод FigureCollection.Save(BaseStream stream)
                //и записываем path в свойство FigureCollection.FileName
                try
                {
                    if (saveFileDialog.FilterIndex == 1)
                        using (var stream = new BinaryFileStream(path))
                            WindowManager.Instance.ActiveWindow.Figures.Save(stream);
                    else
                        using (var stream = new XmlFileStream(path))
                            WindowManager.Instance.ActiveWindow.Figures.Save(stream);
                    WindowManager.Instance.ActiveWindow.Figures.FileName = path;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + ":" + Environment.NewLine + e.InnerException,
                        "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
