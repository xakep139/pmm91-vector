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
    class Polygon : Interfaces.Figure
    {
        #region Constructors

        /// <summary>
        /// Конструктор произвольного многоугольника
        /// </summary>
        public Polygon(List<Point> points)
        {
            Points = points;
        }

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        public Polygon(Point p1, Point p2, Point p3)
        {
            Points.Add(p1);
            Points.Add(p2);
            Points.Add(p3);
        }

        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        public Polygon(Point p1, Point p2)
        {
            Points.Add(p1);
            Points.Add(p2);
        }

        #endregion

        /// <summary>
        /// Добавление точки
        /// </summary>
        public void AddPoint(Point point)
        {
            Points.Add(point);
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

        public override void SetPoint(int index, Point p)
        {
            Points[index] = p;
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
