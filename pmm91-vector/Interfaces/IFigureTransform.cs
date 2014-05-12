using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Interfaces
{
    public enum eTypeTransformation
    {
        Move,
        Rotate,
        Transform
    }

    /// <summary>
    /// Интерфейс матричного преобразования фигуры
    /// </summary>
    public interface IFigureTransform
    {
        eTypeTransformation TypeTransformation { set; get; }
        Matrix TransformMatrix { set; get; }
        /*  
        /// <summary>
        /// Преобразование фигуры
        /// </summary>
        /// <param name="transParams">Параметры преобразования</param>
        /// <returns>Успешно ли выполнена операция</returns>
        bool Transform(ArrayList transParams);*/

        /// <summary>
        /// Сдвиг фигуры на вектор vector
        /// </summary>
        /// <param name="vector"></param>
        void Move(Point vector);

        /// <summary>
        /// Поворот фигуры вокруг её ценра тяжести на угол angle (в радианах)
        /// </summary>
        void Rotate(double angle);

        /// <summary>
        /// ??????????????????????????????????????????????????????????????????
        /// </summary>
        /// <param name="mark">Маркер фигуры</param>
        /// <param name="newPoint">Новая точка</param>
        /// <returns>Успешно ли выполнена операция</returns>
        bool MoveMarker(Misc.Marker mark, Point newPoint);
    }
}
