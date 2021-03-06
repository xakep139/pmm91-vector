using System;
using System.Linq;
using System.Windows.Media;

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
            for (int curZ = 0; curZ < displayScene.Count; curZ++)
            {
                var figure = displayScene.Single(x => (x.Z == curZ));
                Color oldColor = figure.BoundaryColor;
                if (displayScene.ActiveFigures.Contains(figure))
                    figure.BoundaryColor = Colors.Red;
                figure.Draw(this);
                figure.BoundaryColor = oldColor;
            }
        }

        public void Free_mem()
        {
            this.drawingWindow = null;
        }
    }
}
