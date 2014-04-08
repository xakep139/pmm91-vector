using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Interfaces
{
    /// <summary>
    /// Интерфейс объекта "фигура"
    /// </summary>
    public abstract class IFigure : IGeometryFigure, IGraphicFigure
    {
        private int z;
        private Brush fillColor;
        private Color boundaryColor;
        private IList<Point> points = new List<Point>();

        public Color BoundaryColor
        {
            get { return boundaryColor; }
            set { boundaryColor = value; }
        }

        public Brush FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public int Z
        {
            get { return z; }
            set { z = value;  }
        }

        public IList<Point> Points
        {
            get { return points; }
            protected set { points = value; }
        }

        abstract public Point Center { get; set; }

        abstract public void Transform(IFigureTransform transformer);

        abstract public bool Selection(Point a, Point b);

        abstract public void SetPoint(int index, Point p);

        abstract public IGeometryFigure Intersection(IGeometryFigure figure);

        abstract public IGeometryFigure Union(IGeometryFigure figure);

        abstract public void Draw(IGraphics where);
    }
}
