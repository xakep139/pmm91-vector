using System.Collections.Generic;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс стека команд
    /// </summary>
    /// <typeparam name="ICommand">Класс, реализующий итерфейс команды</typeparam>
    public interface ICommandStack
    {
        /// <summary>
        /// Помещение заданной команды в стек
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        void DoComand(object command);

        /// <summary>
        /// Отмена последней выполненной команды с извлечением из стека
        /// </summary>
        void UndoComand();

        /// <summary>
        /// Повтор последней отменённой команды
        /// </summary>
        void RedoComand();

    }
}