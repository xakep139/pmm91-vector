﻿using System;
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
        Point[] _activePoints = new Point[2];
        Polygon _rectangle = new Polygon();
        bool IsMoving = false;

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

        private void GraphicWindow_MouseMove_Move(object sender, MouseEventArgs e)
        {
            return;
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

        private void GraphicWindow_MouseUp_Move(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            if (IsMoving)
            {
                ArrayList parameteres = new ArrayList();
                _activePoints[1] = e.GetPosition(ActiveWindow);
                Point[] p = new Point[1];
                p[0].X = _activePoints[1].X - _activePoints[0].X;
                p[0].Y = _activePoints[1].Y - _activePoints[0].Y;
                parameteres.Add(p);
                var moveCmd = new pmm91_vector.Implementation.Commands.MoveFigureCmd();
                moveCmd.Execute(parameteres);
                IsMoving = false;
            }
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

        private void GraphicWindow_MouseDown_Move(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            if (ActiveWindow.Figures.Selection(e.GetPosition(ActiveWindow), e.GetPosition(ActiveWindow)).Count > 0)
            {
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }
            _activePoints[0] = e.GetPosition(ActiveWindow);
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
                this.MouseDown -= this.GraphicWindow_MouseDown_Move;
                this.MouseDown -= this.GraphicWindow_MouseDown_AddFigure;

                this.MouseMove -= this.GraphicWindow_MouseMove_Select;
                this.MouseMove -= this.GraphicWindow_MouseMove_Move;
                this.MouseMove -= this.GraphicWindow_MouseMove_AddFigure;

                this.MouseUp -= this.GraphicWindow_MouseUp_Select;
                this.MouseUp -= this.GraphicWindow_MouseUp_Move;
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
                        this.MouseDown += GraphicWindow_MouseDown_AddFigure;
                        this.MouseMove += GraphicWindow_MouseMove_AddFigure;
                        this.MouseUp += GraphicWindow_MouseUp_AddFigure;
                        break;
                    case ToolMode.Move:
                        if (Figures.ActiveFigures.Count > 0)
                        {
                            this.MouseDown += this.GraphicWindow_MouseDown_Move;
                            this.MouseMove += this.GraphicWindow_MouseMove_Move;
                            this.MouseUp += this.GraphicWindow_MouseUp_Move;
                        }
                        break;
                    case ToolMode.Scale:
                        throw new NotImplementedException();
                }
                this._mode = value;
            }
        }

        void GraphicWindow_MouseDown_AddFigure(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            _activePoints[0] = e.GetPosition(ActiveWindow);

            Point[] points = new Point[2];
            points[0] = e.GetPosition(ActiveWindow);
            ActiveWindow.SelectionRect = points;

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

        private void GraphicWindow_MouseMove_AddFigure(object sender, MouseEventArgs e)
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

        void GraphicWindow_MouseUp_AddFigure(object sender, MouseButtonEventArgs e)
        {
            var ActiveWindow = sender as GraphicWindow;
            _activePoints[1] = e.GetPosition(ActiveWindow);

            var cmd = new Implementation.Commands.AddFigureCmd();
            cmd.Execute(_activePoints);
        }

        public Point[] SelectionRect
        {
            get { return this._selectionrect; }
            set { this._selectionrect = value; }
        }
    }
}
