using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Базовый класс для всех фигур
    /// </summary>
    public abstract class BaseFigure : Interfaces.IFigure
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
            set { z = value; }
        }

        public IList<Point> Points
        {
            get { return points; }
            protected set { points = value; }
        }

        abstract public Point Center { get; set; }

        abstract public void Transform(Interfaces.IFigureTransform transformer);

        abstract public bool Selection(Point a, Point b);

        abstract public void SetPoint(int index, Point p);

        abstract public Interfaces.IGeometryFigure Intersection(Interfaces.IGeometryFigure figure);

        abstract public Interfaces.IGeometryFigure Union(Interfaces.IGeometryFigure figure);

        abstract public void Draw(Interfaces.IGraphics where);
    }
}
