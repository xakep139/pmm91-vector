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
        Point[] _selectionrect = new Point[2];
        System.Windows.Shapes.Polygon _rectangle = new System.Windows.Shapes.Polygon();

        public GraphicWindow()
        {
            this._figures = new FigureCollection();
            this._graphics = new Graphics();
            this._stack = new CommandStack();

            this._graphics.Init(this);
            this.Background = Brushes.WhiteSmoke;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.MouseDown += GraphicWindow_MouseDown_None;
            this.MouseUp += GraphicWindow_MouseUp_None;
            this.MouseMove += GraphicWindow_MouseMove_None; ;
        }

        public static void GraphicWindow_MouseMove_None(object sender, MouseEventArgs e)
        {
            try
            {
                var ActiveWindow = sender as GraphicWindow;
                
                Point p = e.GetPosition(ActiveWindow);
                Point p1 = new Point(p.X, ActiveWindow._rectangle.Points[0].Y);
                ActiveWindow._rectangle.Points[1] = p1;
                ActiveWindow._rectangle.Points[2] = p;
                Point p3 = new Point(ActiveWindow._rectangle.Points[0].X, p.Y);
                ActiveWindow._rectangle.Points[3] = p3;
                ActiveWindow._rectangle.UpdateLayout();
            }
            catch
            { }
        }
        public static void GraphicWindow_MouseMove_Ellipse(object sender, MouseEventArgs e)
        {

        }
        public static void GraphicWindow_MouseMove_Polygon(object sender, MouseEventArgs e)
        {

        }
        public static void GraphicWindow_MouseMove_Polyline(object sender, MouseEventArgs e)
        {

        }

        public static void GraphicWindow_MouseUp_None(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
           
            Point[] points = ActiveWindow.SelectionRect;
            points[1] = e.GetPosition(ActiveWindow);
            var Figures = ActiveWindow.Figures.Selection(points[0], points[1]);
            if (Figures.Count > 0)
            {                    
                foreach (Interfaces.IFigure figure in Figures)
                {
                    Color tmp = figure.BoundaryColor;
                    figure.BoundaryColor = Colors.Red;
                    figure.Draw(ActiveWindow.Graph);
                    figure.BoundaryColor = tmp;
                }
                ActiveWindow.Figures.UpdateActiveFigures(Figures);
            }
            else
            {
                foreach (Interfaces.IFigure figure in ActiveWindow.Figures.ActiveFigures)
                {
                    figure.Draw(ActiveWindow.Graph);
                }
                ActiveWindow.Figures.ActiveFigures = Figures;
            }
            //TODO: установить ActiveWindow.Figures.ActiveFigures
            //и если в выделении ничего нет, то выделенные ранее фигуры сделать того же цвета, что они были

            ActiveWindow.Children.Remove(ActiveWindow._rectangle);
        }

        public static void GraphicWindow_MouseUp_Ellipse(object sender, MouseButtonEventArgs e)
        {

        }
        public static void GraphicWindow_MouseUp_Polyline(object sender, MouseButtonEventArgs e)
        {

        }
        public static void GraphicWindow_MouseUp_Polygon(object sender, MouseButtonEventArgs e)
        {

        }

        public static void GraphicWindow_MouseDown_None(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);
            ActiveWindow.SelectionRect = points;

            //отрисовка прямоугольника выделения, не забыть исправить
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

        public static void GraphicWindow_MouseDown_Ellipse(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);

            //Если мы добавляем фигуры:
            var cmd = new Implementation.Commands.AddFigureCmd();
            points[1] = new Point(points[0].X + 100, points[0].Y + 100);
            cmd.Execute(points);

            foreach (Interfaces.IFigure figure in ActiveWindow.Figures.ActiveFigures)
            {
                figure.Draw(ActiveWindow.Graph);
            }
            ActiveWindow.Figures.ActiveFigures.Clear();
    
        }

        public static void GraphicWindow_MouseDown_Polygon(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);

            //Если мы добавляем фигуры:
            var cmd = new Implementation.Commands.AddFigureCmd();
            points[1] = new Point(points[0].X + 100, points[0].Y + 100);
            cmd.Execute(points);
            foreach (Interfaces.IFigure figure in ActiveWindow.Figures.ActiveFigures)
            {
                figure.Draw(ActiveWindow.Graph);
            }
            ActiveWindow.Figures.ActiveFigures.Clear();
        }

        public static void GraphicWindow_MouseDown_Polyline(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);

            //Если мы добавляем фигуры:
            var cmd = new Implementation.Commands.AddFigureCmd();
            points[1] = new Point(points[0].X + 100, points[0].Y + 100);
            cmd.Execute(points);
            foreach (Interfaces.IFigure figure in ActiveWindow.Figures.ActiveFigures)
            {
                figure.Draw(ActiveWindow.Graph);
            }
            ActiveWindow.Figures.ActiveFigures.Clear();
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

        public Point[] SelectionRect
        {
            get { return this._selectionrect; }
            set { this._selectionrect = value; }
        }
    }
}
