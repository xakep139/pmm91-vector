using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Ломаная линия
    /// </summary>
    class Polyline : Interfaces.IFigure
    {
        public Polyline(List<Point> points)
        {
            _points = points;
        }

        /// <summary>
        /// Добавление точки
        /// </summary>
        public void AddPoint(Point point)
        {
            _points.Add(point);
        }

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
            _points[index] = p;
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
