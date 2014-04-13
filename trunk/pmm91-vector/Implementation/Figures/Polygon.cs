using System;
using System.Collections.Generic;
using System.Windows;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Многоугольник
    /// </summary>
    class Polygon : BaseFigure
    {
        #region Constructors

        /// <summary>
        /// Конструктор произвольного многоугольника
        /// </summary>
        public Polygon(List<Point> points)
            : base(points)
        {           
        }

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        public Polygon(Point p1, Point p2, Point p3)
            : base(new List<Point> { p1, p2, p3})
        {
        }

        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        public Polygon(Point p1, Point p2)
            : base(new List<Point> { p1, p2 })
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
