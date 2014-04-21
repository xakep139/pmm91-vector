using System;
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
            BaseStream stream = null;
            if (path.EndsWith(".bin"))
                stream = new BinaryFileStream(path);
            else
                stream = new XmlFileStream(path);
            WindowManager.Instance.ActiveWindow.Figures.Save(stream);
        }
    }
}
