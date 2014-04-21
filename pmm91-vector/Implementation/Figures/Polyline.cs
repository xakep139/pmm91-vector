using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Ломаная линия
    /// </summary>
    [Serializable()]
    class Polyline : BaseFigure
    {
        /// <summary>
        /// Конструктор ломаной
        /// </summary>
        /// <param name="points">Коллекция точек ломаной</param>
        public Polyline(IEnumerable<Point> points)
            : base(points)
        {
        }

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

        public override bool Selection(Point a, Point b)
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
            var polyline = new System.Windows.Shapes.Polyline();
            foreach (Point pt in this.Points)
                //TODO: учесть локальную ось X
                polyline.Points.Add(new Point(pt.X + this.Center.X, pt.Y + this.Center.Y));
            polyline.Fill = this.FillBrush;
            polyline.Stroke = new SolidColorBrush(this.BoundaryColor);
            where.DrawingSurface.Children.Add(polyline);
        }

        #endregion
    }
}
