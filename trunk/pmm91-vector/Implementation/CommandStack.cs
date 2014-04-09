using System;
using System.Collections.Generic;
using System.Linq;
using pmm91_vector.Interfaces;

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
        /// Стек отменённых команд
        /// </summary>
        private Stack<ICommand> _stackRedo = new Stack<ICommand>();
        private static CommandStack instance = null;

        /// <summary>
        /// Конструктор закрыт, т.к. используется шаблон "Одиночка"
        /// </summary>
        private CommandStack() { }

        /// <summary>
        /// Сущность объекта-одиночки "стек команд"
        /// </summary>
        public static CommandStack Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandStack();
                }
                return instance;
            }
        }

        public void DoCommand(ICommand command)
        {
            this._stackRedo.Clear();        //Стек отменённых команд очищаем
            this._stackUndo.Push(command);  //Добавляем выполняемую команду в основной стек
        }

        public void UndoCommand()
        {
            ////
            ////    Подумать насчёт того, как сделать так, чтобы отменить изменения, сделанные командой
            ////
            throw new NotImplementedException();
            this._stackRedo.Push(this._stackUndo.Pop());
        }

        public void RedoCommand()
        {
            ////
            ////    Подумать насчёт того, где хранить параметры команды (сейчас задал как null)
            ////
            this._stackUndo.Push(this._stackRedo.Pop());
            this._stackUndo.Peek().Execute(null);
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
