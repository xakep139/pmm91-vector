using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс стека команд
    /// </summary>
    /// <typeparam name="ICommand">Класс, реализующий интерфейс команды</typeparam>
    public interface ICommandStack : ICollection<ICommand>
    {
        /// <summary>
        /// Выполнение заданной команды
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        void DoCommand(ICommand command);

        /// <summary>
        /// Отмена последней выполненной команды
        /// </summary>
        void UndoCommand();

        /// <summary>
        /// Повтор последней отменённой команды
        /// </summary>
        void RedoCommand();

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
