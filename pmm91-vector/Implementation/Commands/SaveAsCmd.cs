using System;
using System.IO;
using Microsoft.Win32;

namespace pmm91_vector.Implementation.Commands
{
    public class SaveAsCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

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
                //тут вызываем метод FigureCollection.Save(Stream fileStream)
                //и записываем path в свойство FigureCollection.FileName
                throw new NotImplementedException();
            }
        }
    }
}
