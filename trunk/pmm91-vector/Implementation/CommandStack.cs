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
        private Stack<Interfaces.ICommand> _stackUndo = new Stack<Interfaces.ICommand>();
        
        /// <summary>
        /// Стек отменённых команд
        /// </summary>
        private Stack<Interfaces.ICommand> _stackRedo = new Stack<Interfaces.ICommand>();
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

        public void DoComand(pmm91_vector.Interfaces.ICommand command)
        {
            ////
            ////    Подумать насчёт того, следует ли выполнять команду здесь
            ////
            throw new NotImplementedException();
            this._stackRedo.Clear();        //Стек отменённых команд очищаем
            this._stackUndo.Push(command);  //Добавляем выполняемую команду в основной стек
        }

        public void UndoComand()
        {
            ////
            ////    Подумать насчёт того, как сделать так, чтобы отменить изменения, сделанные командой
            ////
            throw new NotImplementedException();
            this._stackRedo.Push(this._stackUndo.Pop());
        }

        public void RedoComand()
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

        void ICollection<Interfaces.ICommand>.Add(Interfaces.ICommand item)
        {
            this._stackUndo.Push(item);
        }

        void ICollection<Interfaces.ICommand>.Clear()
        {
            this._stackRedo.Clear();
            this._stackUndo.Clear();
        }

        bool ICollection<Interfaces.ICommand>.Contains(Interfaces.ICommand item)
        {
            return this._stackUndo.Contains(item);
        }

        void ICollection<Interfaces.ICommand>.CopyTo(Interfaces.ICommand[] array, int arrayIndex)
        {
            this._stackUndo.CopyTo(array, arrayIndex);
        }

        int ICollection<Interfaces.ICommand>.Count
        {
            get { return this._stackUndo.Count; }
        }

        bool ICollection<Interfaces.ICommand>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<Interfaces.ICommand>.Remove(Interfaces.ICommand item)
        {
            var tmp = this._stackUndo.ToList();
            bool isRemoved = tmp.Remove(item);
            this._stackUndo = new Stack<Interfaces.ICommand>(tmp);
            return isRemoved;
        }

        IEnumerator<Interfaces.ICommand> IEnumerable<Interfaces.ICommand>.GetEnumerator()
        {
            return this._stackUndo.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._stackUndo.GetEnumerator();
        }

    }
}
