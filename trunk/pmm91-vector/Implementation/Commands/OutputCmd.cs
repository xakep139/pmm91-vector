using System;
using System.IO;
using Microsoft.Win32;

namespace pmm91_vector.Implementation.Commands
{
    class OutputCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt"; //например, txt
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            var result = saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = saveFileDialog.FileName;
                StreamReader sw = new StreamReader(path);
                //тут вызываем метод bool Save(Stream fileStream)
            }
        }
    }
}
