using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс стека команд
    /// </summary>
    /// <typeparam name="ICommand">Класс, реализующий итерфейс команды</typeparam>
    public interface ICommandStack : ICollection<pmm91_vector.Interfaces.ICommand>
    {
        /// <summary>
        /// Выполнение заданной команды
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        void DoComand(pmm91_vector.Interfaces.ICommand command);

        /// <summary>
        /// Отмена последней выполненной команды
        /// </summary>
        void UndoComand();

        /// <summary>
        /// Повтор последней отменённой команды
        /// </summary>
        void RedoComand();

        /// <summary>
        /// Проверка возможности отмены последней выполненной команды
        /// </summary>
        /// <returns>Возвращает true, если команду можно отменить</returns>
        bool CanUndo();

        /// <summary>
        /// Проверка возможности повтора последней отменённой команды
        /// </summary>
        /// <returns>Возвращает true, если команду можно повторить</returns>
        bool CanRedo();
    }
}
