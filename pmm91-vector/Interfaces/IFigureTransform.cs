using System.Collections;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// TransformType - тип преобразования: перемещение/вращение/масштаб
    /// </summary>
    public enum TransformType { Shift, Rotate, Scale };

    /// <summary>
    /// Интерфейс матричного преобразования фигуры
    /// </summary>
    public interface IFigureTransform
    {        
        /// <summary>
        /// Преобразование фигуры
        /// </summary>
        /// <param name="transType">Тип преобразования</param>
        /// <param name="transParams">Параметры преобразования</param>
        /// <returns>Успешно ли выполнена операция</returns>
        bool Transform(TransformType transType, ArrayList transParams);

        /// <summary>
        /// ??????????????????????????????????????????????????????????????????
        /// </summary>
        /// <param name="mark">Маркер фигуры</param>
        /// <param name="newPoint">Новая точка</param>
        /// <returns>Успешно ли выполнена операция</returns>
        bool MoveMarker(Marker mark, Point newPoint);
    }
}
