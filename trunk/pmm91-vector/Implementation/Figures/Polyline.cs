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
        #region Конструкторы

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

        #endregion

        /// <summary>
        /// Добавление точки
        /// </summary>
        /// <param name="point">Точка в глобальной системе координат</param>
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
            var leftTop = new Point(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
            var rightBottom = new Point(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
            //Для каждого отрезка ломаной проверям, пресекается ли он со сторонами прямоуголника выделения.
            for (int i = 0; i < points.Count - 1; i++)
            {
                var p1 = points[i];
                var p2 = points[i + 1];

                if (LinesIntersection(p1, p2, leftTop, new Point(rightBottom.X, leftTop.Y)) ||
                    LinesIntersection(p1, p2, new Point(rightBottom.X, leftTop.Y), rightBottom) ||
                    LinesIntersection(p1, p2, rightBottom, new Point(leftTop.X, rightBottom.Y)) ||
                    LinesIntersection(p1, p2, new Point(leftTop.X, rightBottom.Y), leftTop))
                    return true;
            }
            //Если ломанная не пересекается с прямоугольником выделения, то, возможно, она лежит внутри него.
            //Проверим вложенность для одной точки.
            var p = points[0];
            if (p.X > leftTop.X && p.X < rightBottom.X && p.Y > leftTop.Y && p.Y < rightBottom.Y)
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

            var globalPoints = Local2Global();
            foreach (Point pt in globalPoints)
                polyline.Points.Add(new Point(pt.X, pt.Y));

            polyline.Stroke = new SolidColorBrush(this.BoundaryColor);
            where.DrawingSurface.Children.Insert(Z, polyline);
            this._shapeFigure = polyline;
        }

        #endregion

        #region ICloneable

        public override object Clone()
        {
            var res = new Polyline(this.Local2Global());
            res.BoundaryColor = this.BoundaryColor;
            res.FillBrush = this.FillBrush;
            res.Z = this.Z;
            res.AxisX = this.AxisX;
            res.Center = this.Center;
            return res;
        }

        #endregion
    }
}
