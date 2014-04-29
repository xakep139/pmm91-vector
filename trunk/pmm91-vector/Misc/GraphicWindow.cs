using System;
using System.Windows.Controls;
using System.Windows.Media;

using pmm91_vector.Implementation;

namespace pmm91_vector.Misc
{
    public enum ToolMode
    {
        None,
        Polyline,
        Polygon,
        Ellipse
    }

    /// <summary>
    /// Окно для отрисовки фигур
    /// </summary>
    public class GraphicWindow : Canvas
    {
        CommandStack _stack = null;
        Graphics _graphics = null;
        FigureCollection _figures = null;
        ToolMode _mode = ToolMode.None;


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

        public ToolMode Mode
        {
            get { return this._mode; }
            set { this._mode = value; }
        }
    }
}
