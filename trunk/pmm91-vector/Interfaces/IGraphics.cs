using System.Windows.Controls;
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
        Misc.GraphicWindow DrawingSurface { get; }

        /// <summary>
        /// Инициализация графики в заданном окне
        /// </summary>
        /// <param name="displayWindow">Окно для отображения</param>
        void Init(Misc.GraphicWindow displayWindow);

        /// <summary>
        /// Отрисовка заданного набора фигур в контексте отображения
        /// </summary>
        /// <param name="displayScene">Набор фигур для отрисовки</param>
        void Paint(IFigureCollection displayScene);

        /// <summary>
        /// Освобождение памяти
        /// </summary>
        void Free_mem();
    }
}
