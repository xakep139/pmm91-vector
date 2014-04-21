using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Многоугольник
    /// </summary>
    [Serializable()]
    public class Polygon : BaseFigure
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор произвольного многоугольника
        /// </summary>
        /// <param name="points">Коллекция точек многоугольника</param>
        public Polygon(IEnumerable<Point> points)
            : base(points)
        {           
        }

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        /// <param name="p1">Первая вершина треугольника</param>
        /// <param name="p2">Вторая вершина треугольника</param>
        /// <param name="p3">Третья вершина треугольника</param>
        public Polygon(Point p1, Point p2, Point p3)
            : base(new List<Point> { p1, p2, p3 })
        {
        }

        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        /// <param name="p1">Одна из вершин прямоугольника</param>
        /// <param name="p2">Противоположная вершина</param>
        public Polygon(Point p1, Point p2)
            : base(new List<Point> { p1, new Point(p1.X, p2.Y), p2, new Point(p2.X, p1.Y) })
        {
        }

        #endregion

       /// <summary>
       /// Добавление точки
       /// </summary>
       /// <param name="point">Координаты точки в глобальной системе координат</param>
        public void AddPoint(Point point)
        {
            var globalPoints = Local2Global();
            globalPoints.Add(point);
            SetPoints(globalPoints);
        }

        #region IGeometryFigure
     
        public override void Transform(Interfaces.IFigureTransform transformer)
        {
            throw new NotImplementedException();
        }

        public override  bool Selection(Point a, Point b)
        {
            throw new NotImplementedException();
        }

        public override Interfaces.IGeometryFigure Intersection(Interfaces.IGeometryFigure figure)
        {
            throw new NotImplementedException();
        }

        public override Interfaces.IGeometryFigure Union(Interfaces.IGeometryFigure figure)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IGraphicFigure

        public override void Draw(Interfaces.IGraphics where)
        {
            var polygon = new System.Windows.Shapes.Polygon();
            foreach (Point pt in this.Points)
                //TODO: учесть локальную ось X
                polygon.Points.Add(new Point(pt.X + this.Center.X, pt.Y + this.Center.Y));
            polygon.Fill = this.FillBrush;
            polygon.Stroke = new SolidColorBrush(this.BoundaryColor);
            where.DrawingSurface.Children.Add(polygon);
        }

        #endregion
    }
}
