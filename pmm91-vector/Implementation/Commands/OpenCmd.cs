using System;
using System.IO;
using Microsoft.Win32;
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
            openFileDialog.FilterIndex = 1;

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = openFileDialog.FileName;
                //В зависимости от типа файла создаём Streamer'а (наследника BaseStream)
                //и вызываем метод FigureCollection.Load(BaseStream stream)
                //и записываем path в свойство FigureCollection.FileName
                BaseStream stream = null;
                if (openFileDialog.FilterIndex == 1)
                    stream = new BinaryFileStream(path);
                else
                    stream = new XmlFileStream(path);
                var newWindow = WindowManager.Instance.NewWindow();
                newWindow.Figures.Load(stream);
                newWindow.Figures.FileName = path;
                //Вызываем отрисовку:
                newWindow.Graph.Paint(newWindow.Figures);
            }
        }
    }
}
