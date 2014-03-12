namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс объекта "графическая фигура"
    /// </summary>
    public interface IGraphicFigure
    {
        /// <summary>
        /// Z-координата фигуры
        /// </summary>
        int Z { get; set; }

        /// <summary>
        /// Цвет границ фигуры
        /// </summary>
        System.Windows.Media.Color BoundaryColor { get; set; }

        /// <summary>
        /// Кисть закраски фигуры
        /// </summary>
        System.Windows.Media.Brush FillColor { get; set; }

        /// <summary>
        /// Отрисовка фигуры на заданном контексте
        /// </summary>
        /// <param name="where">Контекст для отрисовки</param>
        void Draw(IGraphics where);
    }
}
