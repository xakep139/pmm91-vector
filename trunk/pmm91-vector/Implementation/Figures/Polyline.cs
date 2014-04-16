using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Ломаная линия
    /// </summary>
    class Polyline : BaseFigure
    {
        public Polyline(List<Point> points)
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

        public override void Draw(Panel where)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
