using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

using pmm91_vector.Interfaces;
using pmm91_vector.Implementation.Figures;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Класс реализующий интерфейс графики
    /// </summary>
    public class Graphics : IGraphics
    {
        private Panel drawingPanel;

        public Panel DrawingSurface
        {
            get { return this.drawingPanel; }
        }

        public void Init(Panel displayContext)
        {
            drawingPanel = displayContext;
        }

        public void Paint(IFigureCollection displayScene)
        {
            drawingPanel.Children.Clear();
            foreach (BaseFigure figure in displayScene)
                figure.Draw(this);
        }

        public void Free_mem(System.Windows.Media.Visual displayContext)
        {
            throw new NotImplementedException();
        }
    }
}
