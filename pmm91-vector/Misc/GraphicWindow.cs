using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using pmm91_vector.Implementation;

namespace pmm91_vector.Misc
{
    /// <summary>
    /// Перечисление режимов инструмента
    /// </summary>
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
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.MouseDown += GraphicWindow_MouseDown;
        }

        static void GraphicWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);

            //Если мы добавляем фигуры:
            if (ActiveWindow.Mode != ToolMode.None)
            {
                var cmd = new Implementation.Commands.AddFigureCmd();
                points[1] = new Point(points[0].X + 100, points[0].Y + 100);
                cmd.Execute(points);
            }
            else    //Если мы выделяем:
            {
                points[1] = new Point(points[0].X + 5, points[0].Y + 5);
                var Figures = ActiveWindow.Figures.Selection(points[0], points[1]);
                //TODO: установить ActiveWindow.Figures.ActiveFigures
                //и если в выделении ничего нет, то выделенные ранее фигуры сделать того же цвета, что они были
                foreach (Interfaces.IFigure figure in Figures)
                {
                    Color tmp = figure.BoundaryColor;
                    figure.BoundaryColor = Colors.Red;
                    figure.Draw(ActiveWindow.Graph);
                    figure.BoundaryColor = tmp;
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
