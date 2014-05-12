using System.Collections.Generic;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс коллекции фигур
    /// </summary>
    /// <typeparam name="IFigure">Класс, реализующий интерфейс объекта "фигура"</typeparam>
    public interface IFigureCollection : IList<Implementation.Figures.BaseFigure>
    {
        /// <summary>
        /// Получение списка фигур в выделении
        /// </summary>
        /// <param name="a">Левая верхняя точка выделения</param>
        /// <param name="b">Превая нижняя точка выделения</param>
        /// <returns>Возвращает коллекцию фигур</returns>
        IList<Implementation.Figures.BaseFigure> Selection(Point a, Point b);

        /// <summary>
        /// Трансформация всех активных фигур
        /// </summary>
        void Transform(Interfaces.IFigureTransform transformer);
        
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

        /// <summary>
        /// Список активных фигур
        /// </summary>
        IList<Implementation.Figures.BaseFigure> ActiveFigures { get; set; }
    }
}
