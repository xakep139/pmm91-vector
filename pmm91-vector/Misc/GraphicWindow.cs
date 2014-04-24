using System;
using System.Windows.Controls;

using pmm91_vector.Implementation;
using System.Windows.Media;

namespace pmm91_vector.Misc
{
    /// <summary>
    /// Окно для отрисовки фигур
    /// </summary>
    public class GraphicWindow : Canvas
    {
        CommandStack _stack = null;
        Graphics _graphics = null;
        FigureCollection _figures = null;

        public GraphicWindow()
        {
            this._figures = new FigureCollection();
            this._graphics = new Graphics();
            this._stack = new CommandStack();

            this._graphics.Init(this);
            this.Background = Brushes.WhiteSmoke;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }

        public FigureCollection Figures
        {
            get { return this._figures; }
        }

        public Graphics Graph
        {
            get { return this._graphics; }
        }

        public CommandStack Stack
        {
            get { return this._stack; }
        }
    }
}
