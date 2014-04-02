using System;
using System.Collections.Generic;
using System.Windows;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс объекта "фигура"
    /// </summary>
    public abstract class Figure : IGeometryFigure, IGraphicFigure
    {
        System.Windows.Media.Color boundaryColor;
        public System.Windows.Media.Color BoundaryColor
        {
            get { return boundaryColor; }
            set { boundaryColor = value; }
        }
        System.Windows.Media.Brush fillColor;
        public System.Windows.Media.Brush FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }
        int z;
        public int Z
        {
            get { return z; }
            set { z = value;  }
        }
        private IList<Point> _points = new List<Point>();

        public IList<Point> Points
        {
            get { return _points; }
            protected set { _points = value; }
        }


        abstract public void Transform(IFigureTransform transformer);

        abstract public bool Selection(Point a, Point b);

        abstract public void SetPoint(int index, Point p);

        abstract public IGeometryFigure Intersection(IGeometryFigure figure);

        abstract public IGeometryFigure Union(IGeometryFigure figure);

        abstract public Point Center     {get;set;}

        abstract public void Draw(IGraphics where);
    }
}
