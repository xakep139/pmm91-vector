using System;
using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс стека команд
    /// </summary>
    /// <typeparam name="ICommand">Класс, реализующий итерфейс команды</typeparam>
    public interface ICommandStack<ICommand> : ICollection<ICommand>
    {
        /// <summary>
        /// Выполнение заданной команды
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        void DoComand(ICommand command);

        /// <summary>
        /// Отмена последней выполненной команды
        /// </summary>
        void UndoComand();

        /// <summary>
        /// Повтор последней отменённой команды
        /// </summary>
        void RedoComand();
    }
}
