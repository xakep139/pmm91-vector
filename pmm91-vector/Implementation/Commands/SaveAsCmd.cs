using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Input;

namespace pmm91_vector.Implementation.Commands
{
    public class SaveAsCmd : Interfaces.ICommand
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            var result = saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = saveFileDialog.FileName;
                StreamReader sw = new StreamReader(path);
                //В зависимости от типа файла создаём Streamer'а (наследника BaseStream)
                //и тут вызываем метод FigureCollection.Save(BaseStream stream)
                //и записываем path в свойство FigureCollection.FileName
                throw new NotImplementedException();
            }
        }
    }
}
