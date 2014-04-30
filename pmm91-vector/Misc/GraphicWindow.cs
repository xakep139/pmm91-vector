using System;
using System.Windows.Controls;
using System.Windows.Media;

using pmm91_vector.Implementation;
using System.Windows;
using System.Collections;

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
            this.MouseDown += newWindow_MouseDown;
        }
        static void newWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Если мы добавляем фигуры
            Point[] points = new Point[2];
            var ActiveWindow = sender as GraphicWindow;
            points[0] = e.GetPosition(sender as GraphicWindow);
            

            if (ActiveWindow.Mode != ToolMode.None)
            {
                var cmd = new pmm91_vector.Implementation.Commands.AddFigureCmd();
                ArrayList ar = new ArrayList();
                points[1] = new Point(points[0].X + 100, points[0].Y + 100);
                ar.Add(points);
                cmd.Execute(ar);
            }
            //Если мы выделяем
            else
            {
                points[1] = new Point(points[0].X + 10, points[0].Y + 10);
                var Figures =ActiveWindow.Figures.Selection(points[0], points[1]);
                foreach (pmm91_vector.Interfaces.IFigure figure in Figures)
                {
                    figure.BoundaryColor = Colors.Red;
                    figure.Draw(ActiveWindow.Graph);
                }
            }
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
