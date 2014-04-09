﻿using System;

namespace pmm91_vector.Implementation.Commands
{
    public class RedoCmd : Interfaces.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return CommandStack.Instance.CanRedo();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            CommandStack.Instance.RedoCommand();
        }
    }
}