using System.Collections.Generic;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс коллекции фигур
    /// </summary>
    /// <typeparam name="IFigure">Класс, реализующий интерфейс объекта "фигура"</typeparam>
    public interface IFigureCollection : IList<IFigure>
    {
        /// <summary>
        /// Получение списка фигур в выделении
        /// </summary>
        /// <param name="a">Левая верхняя точка выделения</param>
        /// <param name="b">Превая нижняя точка выделения</param>
        /// <returns>Возвращает коллекцию фигур</returns>
        IList<IFigure> Selection(Point a, Point b);
        
        // Объединение - ?
        
        /// <summary>
        /// Загрузка коллекции фигур из заданного потока
        /// </summary>
        /// <param name="Stream">Поток для загрузки</param>
        /// <returns>Возвращает успешность сохранения</returns>
        bool Load(Streamers.BaseStream stream);

        /// <summary>
        /// Сохранение коллекции фигур в заданный поток
        /// </summary>
        /// <param name="Stream">Поток для сохранения</param>
        /// <returns>Возвращает успешность сохранения</returns>
        bool Save(Streamers.BaseStream stream);

        /// <summary>
        /// Имя файла, который соответствует теущей коллекции фигур
        /// </summary>
        string FileName { get; set; }
    }
}
