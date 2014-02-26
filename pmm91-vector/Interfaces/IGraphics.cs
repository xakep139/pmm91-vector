using System.Windows.Media;

namespace pmm91_vector.Interfaces
{
    interface IGraphics
    {
        /// <summary>
        /// Инициализация графики в заданном контексте отображения
        /// </summary>
        /// <param name="displayContext">Контекст отображения</param>
        void init(Visual displayContext);

        /// <summary>
        /// Отрисовка заданного набора фигур в контексте отображения
        /// </summary>
        /// <param name="displayScene">Набор фигур для отрисовки</param>
        void paint(IFigureCollection<IFigure> displayScene);

        /// <summary>
        /// Освобождение памяти под заданный контекст отображения
        /// </summary>
        /// <param name="displayContext">Контекст отображения</param>
        void free_mem(Visual displayContext);
    }
}
