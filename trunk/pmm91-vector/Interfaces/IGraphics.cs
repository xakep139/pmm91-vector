﻿using System.Windows.Controls;
﻿using System.Windows.Media;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс графической части
    /// </summary>
    public interface IGraphics
    {
        /// <summary>
        /// Поверхность отрисовки
        /// </summary>
        Panel DrawingSurface { get; }

        /// <summary>
        /// Инициализация графики в заданном контексте отображения
        /// </summary>
        /// <param name="displayContext">Контекст отображения</param>
        void Init(Panel displayContext);

        /// <summary>
        /// Отрисовка заданного набора фигур в контексте отображения
        /// </summary>
        /// <param name="displayScene">Набор фигур для отрисовки</param>
        void Paint(IFigureCollection displayScene);

        /// <summary>
        /// Освобождение памяти под заданный контекст отображения
        /// </summary>
        /// <param name="displayContext">Контекст отображения</param>
        void Free_mem(Visual displayContext);
    }
}
