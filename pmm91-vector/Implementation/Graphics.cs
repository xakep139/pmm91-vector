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

        public void Init(Panel displayContext)
        {
            //DrawingContext drawingContext = ((DrawingVisual)displayContext).RenderOpen();
            //Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
            //drawingContext.DrawRectangle(System.Windows.Media.Brushes.LightBlue, (System.Windows.Media.Pen)null, rect);
            //drawingContext.Close();
        }

        public void Init(Canvas displayCanvas)
        {
            drawingPanel = displayCanvas;
        }

        public void Paint(IFigureCollection displayScene)
        {
            drawingPanel.Children.Clear();
            foreach (BaseFigure figure in displayScene)
                figure.Draw(this.drawingPanel);
        }

        public void Free_mem(System.Windows.Media.Visual displayContext)
        {
            throw new NotImplementedException();
        }
    }
}
