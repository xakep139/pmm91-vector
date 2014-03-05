using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс коллекции фигур
    /// </summary>
    /// <typeparam name="IFigure">Класс, реализующий интерфейс объекта "фигура"</typeparam>
    public interface IFigureCollection<IFigure> : ICollection, ICollection<IFigure>
    {
        /// <summary>
        /// Добавление фигуры
        /// </summary>
        /// <param name="fig">Добавляемая фигура</param>
        /// <returns>Возвращает успешность добавления</returns>
        bool AddFigure(IFigure fig);
        
        /// <summary>
        /// Удаление фигуры
        /// </summary>
        /// <param name="fig">Удаляемая фигура</param>
        /// <returns>Возвращает успешность удаления</returns>
        bool DeleteFigure(IFigure fig);
        
        /// <summary>
        /// Поиск фигуры
        /// </summary>
        /// <param name="fig">Искомая фигура</param>
        /// <returns>Возвращает индекс фигуры</returns>
        int SearchFigure(IFigure fig);

        /// <summary>
        /// Получение списка фигур в выделении
        /// </summary>
        /// <param name="a">Левая верхняя точка выделения</param>
        /// <param name="b">Превая нижняя точка выделения</param>
        /// <returns>Возвращает коллекцию фигур</returns>
        List<IFigure> Selection(Point a, Point b);
        
        // Объединение - ?
        
        /// <summary>
        /// Загрузка коллекции фигур из файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Возвращает коллекцию фигур</returns>
        IFigureCollection<IFigure> Load(string fileName);

        /// <summary>
        /// Сохранение коллекции фигур
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Возвращает успешность сохранения</returns>
        bool Save(string fileName);
    }
}
