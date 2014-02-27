using System;
using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    interface ICommandStack<ICommand> : ICollection<ICommand>
    {
        /// <summary>
        /// Выполнение заданной команды
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        void doComand(ICommand command);

        /// <summary>
        /// Отмена последней выполненной команды
        /// </summary>
        void undoComand();

        /// <summary>
        /// Повтор последней отменённой команды
        /// </summary>
        void redoComand();
    }
}
