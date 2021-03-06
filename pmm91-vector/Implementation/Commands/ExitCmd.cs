﻿using System;
using System.Windows.Input;

namespace pmm91_vector.Implementation.Commands
{
    public class ExitCmd : Interfaces.ICommand
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
            App.Current.Shutdown(0);
        }

    }
}
