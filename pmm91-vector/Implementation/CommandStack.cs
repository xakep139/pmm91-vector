using System;
using System.Collections.Generic;
using System.Linq;

using pmm91_vector.Interfaces;
using pmm91_vector.Misc;
using pmm91_vector.Implementation.Figures;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Класс реализующий интерфейс стека команд
    /// </summary>
    public class CommandStack : ICommandStack
    {
        /// <summary>
        /// Стек выполненных команд
        /// </summary>
        private Stack<ICommand> _stackUndo = new Stack<ICommand>();

        /// <summary>
        /// Стек состояний сцены выполненных команд
        /// </summary>
        private Stack<FigureCollection> _stackFigUndo = new Stack<FigureCollection>();
        
        /// <summary>
        /// Стек отменённых команд
        /// </summary>
        private Stack<ICommand> _stackRedo = new Stack<ICommand>();

        /// <summary>
        /// Стек состояний сцены отменённых команд
        /// </summary>
        private Stack<FigureCollection> _stackFigRedo = new Stack<FigureCollection>();

        public void DoCommand(ICommand command)
        {
            this._stackRedo.Clear();        //Стек отменённых команд очищаем
            this._stackFigRedo.Clear();
            this._stackUndo.Push(command);  //Добавляем выполняемую команду в основной стек
            this._stackFigUndo.Push(new FigureCollection(WindowManager.Instance.ActiveWindow.Figures));
        }

        public void UndoCommand()
        {
            this._stackRedo.Push(this._stackUndo.Pop());
            this._stackFigRedo.Push(WindowManager.Instance.ActiveWindow.Figures);
            WindowManager.Instance.ActiveWindow.Figures = this._stackFigUndo.Pop();
            WindowManager.Instance.ActiveWindow.Graph.Paint(WindowManager.Instance.ActiveWindow.Figures);
        }

        public void RedoCommand()
        {
            this._stackUndo.Push(this._stackRedo.Pop());
            this._stackFigUndo.Push(WindowManager.Instance.ActiveWindow.Figures);
            WindowManager.Instance.ActiveWindow.Figures = this._stackFigRedo.Pop();
            WindowManager.Instance.ActiveWindow.Graph.Paint(WindowManager.Instance.ActiveWindow.Figures);
        }

        public bool CanUndo()
        {
            return (this._stackUndo.Count > 0);
        }

        public bool CanRedo()
        {
            return (this._stackRedo.Count > 0);
        }

        void ICollection<ICommand>.Add(ICommand item)
        {
            this._stackUndo.Push(item);
        }

        void ICollection<ICommand>.Clear()
        {
            this._stackRedo.Clear();
            this._stackUndo.Clear();
        }

        bool ICollection<ICommand>.Contains(ICommand item)
        {
            return this._stackUndo.Contains(item);
        }

        void ICollection<ICommand>.CopyTo(ICommand[] array, int arrayIndex)
        {
            this._stackUndo.CopyTo(array, arrayIndex);
        }

        int ICollection<ICommand>.Count
        {
            get { return this._stackUndo.Count; }
        }

        bool ICollection<ICommand>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<ICommand>.Remove(ICommand item)
        {
            var tmp = this._stackUndo.ToList();
            bool isRemoved = tmp.Remove(item);
            this._stackUndo = new Stack<ICommand>(tmp);
            return isRemoved;
        }

        IEnumerator<ICommand> IEnumerable<ICommand>.GetEnumerator()
        {
            return this._stackUndo.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._stackUndo.GetEnumerator();
        }

    }
}
