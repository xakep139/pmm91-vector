using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Ломаная линия
    /// </summary>
    [Serializable]
    public class Polyline : BaseFigure
    {
        /// <summary>
        /// Конструктор без параметров (по умолчанию)
        /// </summary>
        public Polyline() { }

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

        public override bool Selection(Point a, Point b)
        {
            var points = Local2Global();
            //Для каждого отрезка ломаной проверям, пресекается ли он со сторонами прямоуголника выделения.
            for (int i = 0; i < points.Count - 1; i++)
            {
                var p1 = points[i];
                var p2 = points[i + 1];

                if (LinesIntersection(p1, p2, a, new Point(b.X, a.Y)) ||
                    LinesIntersection(p1, p2, new Point(b.X, a.Y), b) ||
                    LinesIntersection(p1, p2, b, new Point(a.X, b.Y)) ||
                    LinesIntersection(p1, p2, new Point(a.X, b.Y), a))
                    return true;
            }
            //Если ломанная не пересекается с прямоугольником выделения, то, возможно, она лежит внутри него.
            //Проверим вложенность для одной точки.
            var p = points[0];
            if (p.X > a.X && p.X < b.X && p.Y > a.Y && p.Y < b.Y)
                return true;

            return false;
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
            if (this._shapeFigure != null)
                where.DrawingSurface.Children.Remove(this._shapeFigure);
            var polyline = new System.Windows.Shapes.Polyline();
            foreach (Point pt in this.Points)
                //TODO: учесть локальную ось X
                polyline.Points.Add(new Point(pt.X + this.Center.X, pt.Y + this.Center.Y));
            polyline.Stroke = new SolidColorBrush(this.BoundaryColor);
            where.DrawingSurface.Children.Add(polyline);
            this._shapeFigure = polyline;
        }

        #endregion
    }
}
