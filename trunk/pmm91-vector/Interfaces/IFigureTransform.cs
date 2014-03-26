using System.Collections;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс матричного преобразования фигуры
    /// </summary>
    public interface IFigureTransform
    {        
        /// <summary>
        /// Преобразование фигуры
        /// </summary>
        /// <param name="transParams">Параметры преобразования</param>
        /// <returns>Успешно ли выполнена операция</returns>
        bool Transform(ArrayList transParams);

        /// <summary>
        /// ??????????????????????????????????????????????????????????????????
        /// </summary>
        /// <param name="mark">Маркер фигуры</param>
        /// <param name="newPoint">Новая точка</param>
        /// <returns>Успешно ли выполнена операция</returns>
        bool MoveMarker(Misc.Marker mark, Point newPoint);
    }
}
