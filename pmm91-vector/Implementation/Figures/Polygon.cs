using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Многоугольник
    /// </summary>
    class Polygon : Interfaces.IFigure
    {
        #region IGeometryFigure

        private List<Point> _points = new List<Point>();

        public IList<Point> Points
        {
            get { return _points; }
        }

        public void Transform(Interfaces.IFigureTransform transformer)
        {
            throw new NotImplementedException();
        }

        public bool Selection(Point a, Point b)
        {
            throw new NotImplementedException();
        }

        public void SetPoint(int index, Point p)
        {
            throw new NotImplementedException();
        }

        public Interfaces.IGeometryFigure Intersection(Interfaces.IGeometryFigure figure)
        {
            throw new NotImplementedException();
        }

        public Interfaces.IGeometryFigure Union(Interfaces.IGeometryFigure figure)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IGraphicFigure

        public int Z
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

        public System.Windows.Media.Color BoundaryColor
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

        public System.Windows.Media.Brush FillColor
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

        public void Draw(Interfaces.IGraphics where)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
