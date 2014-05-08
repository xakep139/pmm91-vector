using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Многоугольник
    /// </summary>
    [Serializable]
    public class Polygon : BaseFigure
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор без параметров (по умолчанию)
        /// </summary>
        public Polygon() { }

        /// <summary>
        /// Конструктор произвольного многоугольника
        /// </summary>
        /// <param name="points">Коллекция точек многоугольника</param>
        public Polygon(IEnumerable<Point> points)
            : base(points)
        {           
        }

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        /// <param name="p1">Первая вершина треугольника</param>
        /// <param name="p2">Вторая вершина треугольника</param>
        /// <param name="p3">Третья вершина треугольника</param>
        public Polygon(Point p1, Point p2, Point p3)
            : base(new List<Point> { p1, p2, p3 })
        {
        }

        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        /// <param name="p1">Одна из вершин прямоугольника</param>
        /// <param name="p2">Противоположная вершина</param>
        public Polygon(Point p1, Point p2)
            : base(new List<Point> { p1, new Point(p1.X, p2.Y), p2, new Point(p2.X, p1.Y) })
        {
        }

        #endregion

        #region IGeometryFigure

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

        public override bool Selection(Point a, Point b)
        {
            var points = Local2Global();
            int n = points.Count;
            Point p1, p2;
            //Для каждого отрезка многоугольника проверям пересекается ли он со сторонами прямоугольника выделения:
            for (int i = 0; i < n; i++)
            {
                p1 = points[i];
                p2 = points[(i + 1) % n];

                if (LinesIntersection(p1, p2, a, new Point(b.X, a.Y)) ||
                    LinesIntersection(p1, p2, new Point(b.X, a.Y), b) ||
                    LinesIntersection(p1, p2, b, new Point(a.X, b.Y)) ||
                    LinesIntersection(p1, p2, new Point(a.X, b.Y), a))
                    return true;
            }
            //Если многоугольник не пересекается с прямоугольником выделения, то, возможно, он лежит внутри него.
            //Проверим вложенность для одной точки:
            var point = points[0];
            if (point.X > a.X && point.X < b.X && point.Y > a.Y && point.Y < b.Y)
                return true;

            //Возможно, прямоугольник выделения лежит внутри многоугольника.
            //Проверим вложенность для одной точки:
            //Из точки пустим луч в случайном направлении и посчитаем, сколько сторон многоугольника пересекает этот луч. 
            //Если нечетное - точка внутри многоугольника.
            p1 = a;
            p2 = new Point();
            Random rand = new Random();
            var stop = false;
            while (!stop)
            {
                p2 = new Point(int.MaxValue - rand.NextDouble(), int.MaxValue - rand.NextDouble());

                var repeat = false;
                //Проверяем, не является ли ситуация вырожденной: луч пересекает вершину многоугольника
                //Если да, то генерируем новое направление.
                var A = p1.Y - p2.Y;
                var B = p2.X - p1.X;
                var C = p1.X * p2.Y - p2.X * p1.Y;
                foreach (var p in points)
                {
                    if (A * p.X + B * p.Y + C == 0)
                    {
                        repeat = true;
                        break;
                    }
                }
                if (repeat)
                    continue;
                stop = true;
            }
            var count = 0;
            for (int i = 0; i < n; i++)
            {
                var pp1 = points[i];
                var pp2 = points[(i + 1) % n];

                if (LinesIntersection(p1, p2, pp1, pp2))
                    count++;
            }
            return (count % 2) != 0;
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
            var polygon = new System.Windows.Shapes.Polygon();
            foreach (Point pt in this.Points)
                //TODO: учесть локальную ось X
                polygon.Points.Add(new Point(pt.X + this.Center.X, pt.Y + this.Center.Y));
            polygon.Fill = this.FillBrush;
            polygon.Stroke = new SolidColorBrush(this.BoundaryColor);
            where.DrawingSurface.Children.Add(polygon);
            this._shapeFigure = polygon;
        }

        #endregion
    }
}
