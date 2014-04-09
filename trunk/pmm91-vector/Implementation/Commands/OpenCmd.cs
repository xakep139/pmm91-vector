using System;
using System.IO;
using Microsoft.Win32;

namespace pmm91_vector.Implementation.Commands
{
    public class OpenCmd : Interfaces.ICommand
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = openFileDialog.FileName;
                StreamReader sr = new StreamReader(path);
                //тут вызываем метод FigureCollection.Load(Stream fileStream)
                //и записываем path в свойство FigureCollection.FileName
                throw new NotImplementedException();
            }
        }
    }
}
