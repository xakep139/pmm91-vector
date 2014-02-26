using System;
using System.Collections;
using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    interface IComandStack : ICollection<ICommand>
    {
        /// <summary>
        /// Выполнение заданной команды
        /// </summary>
        /// <param name="comand">Команда для выполнения</param>
        void doComand(ICommand comand);

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
