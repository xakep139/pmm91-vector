using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmm91_vector.Implementation
{
    public class CommandStack : Interfaces.ICommandStack
    {
        private int _curCommand = -1;
        private List<Interfaces.ICommand> _stack = new List<Interfaces.ICommand>();

        void Interfaces.ICommandStack.DoComand(Interfaces.ICommand command)
        {
            throw new NotImplementedException();
            this._curCommand++;
            if (this._curCommand < this._stack.Count)
                this._stack.RemoveRange(this._curCommand, this._stack.Count - this._curCommand);
            this._stack.Add(command);
        }

        void Interfaces.ICommandStack.UndoComand()
        {
            throw new NotImplementedException();
            this._curCommand--;
        }

        void Interfaces.ICommandStack.RedoComand()
        {
            throw new NotImplementedException();
            this._curCommand++;
        }

        bool Interfaces.ICommandStack.CanUndo()
        {
            return (this._curCommand > 0);
        }

        bool Interfaces.ICommandStack.CanRedo()
        {
            return (this._curCommand < this._stack.Count - 1);
        }

        void ICollection<Interfaces.ICommand>.Add(Interfaces.ICommand item)
        {
            this._stack.Add(item);
        }

        void ICollection<Interfaces.ICommand>.Clear()
        {
            this._stack.Clear();
        }

        bool ICollection<Interfaces.ICommand>.Contains(Interfaces.ICommand item)
        {
            return this._stack.Contains(item);
        }

        void ICollection<Interfaces.ICommand>.CopyTo(Interfaces.ICommand[] array, int arrayIndex)
        {
            this._stack.CopyTo(array, arrayIndex);
        }

        int ICollection<Interfaces.ICommand>.Count
        {
            get { return this._stack.Count; }
        }

        bool ICollection<Interfaces.ICommand>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<Interfaces.ICommand>.Remove(Interfaces.ICommand item)
        {
            return this._stack.Remove(item);
        }

        IEnumerator<Interfaces.ICommand> IEnumerable<Interfaces.ICommand>.GetEnumerator()
        {
            return this._stack.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._stack.GetEnumerator();
        }
    }
}
