using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

using pmm91_vector.Misc;
using pmm91_vector.Interfaces;
using pmm91_vector.Implementation.Figures;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Класс реализующий интерфейс графики
    /// </summary>
    public class Graphics : IGraphics
    {
        private GraphicWindow drawingWindow;

        public GraphicWindow DrawingSurface
        {
            get { return this.drawingWindow; }
        }

        public void Init(GraphicWindow displayContext)
        {
            drawingWindow = displayContext;
        }

        public void Paint(IFigureCollection displayScene)
        {
            drawingWindow.Children.Clear();
            foreach (BaseFigure figure in displayScene)
                figure.Draw(this);
        }

        public void Free_mem()
        {
            this.drawingWindow = null;
        }
    }
}
