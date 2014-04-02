using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Эллипс
    /// </summary>
    class Ellipse : Interfaces.Figure
    {
        public Ellipse(Point p1, Point p2)
        {
            Points.Add(p1);
            Points.Add(p2);
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

        public override void SetPoint(int index, Point p)
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


        public override Point Center
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
