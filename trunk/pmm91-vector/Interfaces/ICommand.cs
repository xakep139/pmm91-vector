namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс команды
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнение заданной команды
        /// </summary>
        void Execute();

        /// <summary>
        /// Отмена заданной команды
        /// </summary>
        void Undo();

        /// <summary>
        /// Проверка на возможность отмены команды
        /// </summary>
        /// <returns>Возвращает возможность отмены</returns>
        bool CanExecute();
    }
}
