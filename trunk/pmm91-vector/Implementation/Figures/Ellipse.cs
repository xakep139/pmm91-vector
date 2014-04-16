using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Эллипс
    /// </summary>
    class Ellipse : BaseFigure
    {
        public Ellipse(Point p1, Point p2)
            : base(new List<Point> { p1, p2})
        {
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
