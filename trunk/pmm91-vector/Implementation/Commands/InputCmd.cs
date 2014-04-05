using System;
using System.IO;
using Microsoft.Win32;

namespace pmm91_vector.Implementation.Commands
{
    public class InputCmd:Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt"; //например, txt
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                string path = openFileDialog.FileName;
                StreamReader sr = new StreamReader(path);
                //тут вызываем метод bool Load(Stream fileStream)
            }
        }
    }
}
