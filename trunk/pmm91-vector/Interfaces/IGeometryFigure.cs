using System.Collections.Generic;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс объекта "геометрическая фигура"
    /// </summary>
    public interface IGeometryFigure
    {
        /// <summary>
        /// Список точек фигуры
        /// </summary>
        IList<Point> Points { get; }

        /// <summary>
        /// Трансформация фигуры заданным преобразованием
        /// </summary>
        /// <param name="transformer">Преобразование</param>
        void Transform(IFigureTransform transformer);

        /// <summary>
        /// Проверка пересечения заданной области выделения и фигуры
        /// </summary>
        /// <param name="a">Левая верхняя точка выделения</param>
        /// <param name="b">Превая нижняя точка выделения</param>
        /// <returns>Возвращает принадлежность точки</returns>
        bool Selection(Point a, Point b);

        /// <summary>
        /// Задание новых координат некоторой точке фигуры
        /// </summary>
        /// <param name="index">Индекс изменяемой точки</param>
        /// <param name="p">Новые координаты(в глобальной системе координат)</param>
        void SetPoint(int index, Point p);

        /// <summary>
        /// Получение новой фигуры как результат пересечения текущей и заданной
        /// </summary>
        /// <param name="figure">Фигура для пересечения</param>
        /// <returns>Возвращает новую фигуру</returns>
        IGeometryFigure Intersection(IGeometryFigure figure);

        /// <summary>
        /// Получение новой фигуры как результат объединения текущей и заданной
        /// </summary>
        /// <param name="figure">Фигура для объединения</param>
        /// <returns>Возвращает новую фигуру</returns>
        IGeometryFigure Union(IGeometryFigure figure);

        /// <summary>
        /// Получение и установка центра фигуры 
        /// </summary>
        Point Center { get; set; }
    }
}
