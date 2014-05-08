using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using pmm91_vector.Implementation;

namespace pmm91_vector.Misc
{
    /// <summary>
    /// Перечисление режимов инструмента
    /// </summary>
    public enum ToolMode
    {
        Select,
        Polyline,
        Polygon,
        Ellipse,
        Move,
        Scale
    }

    /// <summary>
    /// Окно для отрисовки фигур
    /// </summary>
    public class GraphicWindow : Canvas
    {
        CommandStack _stack = null;
        Graphics _graphics = null;
        FigureCollection _figures = null;
        ToolMode _mode = ToolMode.Select;
        Point[] _selectionrect = new Point[2];
        Polygon _rectangle = new Polygon();

        public GraphicWindow()
        {
            this._figures = new FigureCollection();
            this._graphics = new Graphics();
            this._stack = new CommandStack();

            this._graphics.Init(this);
            this.Background = Brushes.WhiteSmoke;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.MouseDown += GraphicWindow_MouseDown_Select;
            this.MouseUp += GraphicWindow_MouseUp_Select;
            this.MouseMove += GraphicWindow_MouseMove_Select;
        }

        private void GraphicWindow_MouseMove_Select(object sender, MouseEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;

            if (ActiveWindow._rectangle != null && ActiveWindow._rectangle.Points.Count != 0)
            {
                Point p = e.GetPosition(ActiveWindow);
                Point p1 = new Point(p.X, ActiveWindow._rectangle.Points[0].Y);
                ActiveWindow._rectangle.Points[1] = p1;
                ActiveWindow._rectangle.Points[2] = p;
                Point p3 = new Point(ActiveWindow._rectangle.Points[0].X, p.Y);
                ActiveWindow._rectangle.Points[3] = p3;
                ActiveWindow._rectangle.UpdateLayout();
            }
        }

        private void GraphicWindow_MouseUp_Select(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;

            ActiveWindow.Children.Remove(ActiveWindow._rectangle);
            ActiveWindow._rectangle = null;
            Point[] selPoints = ActiveWindow.SelectionRect;
            selPoints[1] = e.GetPosition(ActiveWindow);
            ActiveWindow.Figures.ActiveFigures = ActiveWindow.Figures.Selection(selPoints[0], selPoints[1]);
            ActiveWindow.Graph.Paint(ActiveWindow.Figures);
        }

        private void GraphicWindow_MouseDown_Select(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);
            ActiveWindow.SelectionRect = points;

            //TODO: отрисовка прямоугольника выделения, не забыть исправить
            ActiveWindow._rectangle = new System.Windows.Shapes.Polygon();
            ActiveWindow._rectangle.Points.Add(points[0]);
            ActiveWindow._rectangle.Points.Add(points[0]);
            ActiveWindow._rectangle.Points.Add(points[0]);
            ActiveWindow._rectangle.Points.Add(points[0]);
            ActiveWindow._rectangle.Stroke = new SolidColorBrush(Colors.Black);
            DoubleCollection dc = new DoubleCollection(2);
            dc.Add(2);
            dc.Add(1);
            ActiveWindow._rectangle.StrokeDashArray = dc;
            ActiveWindow.Children.Add(ActiveWindow._rectangle); 
        }


        public FigureCollection Figures
        {
            get { return this._figures; }
            set { this._figures = value; }
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
            set
            {
                this.MouseDown -= this.GraphicWindow_MouseDown_Select;
                this.MouseMove -= this.GraphicWindow_MouseMove_Select;
                this.MouseUp -= this.GraphicWindow_MouseUp_Select;
                this.MouseUp -= this.GraphicWindow_MouseUp_AddFigure;

                switch (value)
                {
                    case ToolMode.Select:
                        this.MouseDown += this.GraphicWindow_MouseDown_Select;
                        this.MouseMove += this.GraphicWindow_MouseMove_Select;
                        this.MouseUp += this.GraphicWindow_MouseUp_Select;
                        break;
                    case ToolMode.Polyline:
                    case ToolMode.Polygon:
                    case ToolMode.Ellipse:
                        this.MouseUp += GraphicWindow_MouseUp_AddFigure;
                        break;
                    case ToolMode.Move:
                        throw new NotImplementedException();
                    case ToolMode.Scale:
                        throw new NotImplementedException();
                }
                this._mode = value;
            }
        }

        void GraphicWindow_MouseUp_AddFigure(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);

            //Если мы добавляем фигуры:
            var cmd = new Implementation.Commands.AddFigureCmd();
            points[1] = new Point(points[0].X + 100, points[0].Y + 100);
            cmd.Execute(points);
        }

        public Point[] SelectionRect
        {
            get { return this._selectionrect; }
            set { this._selectionrect = value; }
        }
    }
}
