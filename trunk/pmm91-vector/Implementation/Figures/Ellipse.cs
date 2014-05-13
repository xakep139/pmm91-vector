using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Эллипс
    /// </summary>
    [Serializable]
    public class Ellipse : BaseFigure
    {
        private Point leftTop;
        private Point rightBottom;

        #region Конструкторы
        
        /// <summary>
        /// Конструктор без параметров (по умолчанию)
        /// </summary>
        public Ellipse() { }

        /// <summary>
        /// Конструктор эллипса по двум точкам,
        /// описывающим прямоугольник, в который вписан эллипс
        /// </summary>
        /// <param name="p1">Одна из вершин прямоугольника, в который вписан эллипс</param>
        /// <param name="p2">Противоположная вершина прямоугольника, в который вписан эллипс</param>
        public Ellipse(Point p1, Point p2)
            : this(new List<Point> { p1, p2 })
        {
            CalcBounds();
        }

        /// <summary>
        /// Конструктор эллипса по коллекции из двух точех,
        /// описывающих прямоугольник, в который вписан эллипс
        /// </summary>
        /// <param name="points">Коллекция, состоящая минимум из двух точек.
        /// Первая точка представляет собой одну из вершин прямоугольника, в который вписан эллипс.
        /// Вторая точка - противоположную вершину.
        /// </param>
        public Ellipse(IEnumerable<Point> points)
            : base(points.Take(2))
        {
            if (points == null || points.Count() < 2)
                throw new Exception("Некорректная коллекция точек");
            CalcBounds();
        }

        #endregion

        #region IGeometryFigure

        /// <summary>
        /// Вычисление границ эллипса
        /// </summary>
        private void CalcBounds()
        {
            var globalPoints = Local2Global();
            this.leftTop = new Point(Math.Min(globalPoints[0].X, globalPoints[1].X),
                                     Math.Min(globalPoints[0].Y, globalPoints[1].Y));
            this.rightBottom = new Point(Math.Max(globalPoints[0].X, globalPoints[1].X),
                                     Math.Max(globalPoints[0].Y, globalPoints[1].Y));
        }

        public override bool Selection(Point a, Point b)
        {
            var points = Local2Global();
            int n = points.Count;
            //Вычисление значений квадратов полуосей a,b и центра эллипса
            var center_ellipse = new Point();
            center_ellipse.X = (points[0].X + points[1].X) / 2.0;
            center_ellipse.Y = (points[0].Y + points[1].Y) / 2.0;
            //Если центр эллипса находится внутри прямоугольника выделения
            if (a.X <= b.X && a.Y <= b.Y && center_ellipse.X > a.X && center_ellipse.X < b.X && center_ellipse.Y > a.Y && center_ellipse.Y < b.Y)
                return true;
            if (a.X < b.X && a.Y > b.Y && center_ellipse.X > a.X && center_ellipse.X < b.X && center_ellipse.Y < a.Y && center_ellipse.Y > b.Y)
                return true;
            if (a.X > b.X && a.Y < b.Y && center_ellipse.X < a.X && center_ellipse.X > b.X && center_ellipse.Y > a.Y && center_ellipse.Y < b.Y)
                return true;
            if (a.X > b.X && a.Y > b.Y && center_ellipse.X < a.X && center_ellipse.X > b.X && center_ellipse.Y < a.Y && center_ellipse.Y > b.Y)
                return true;
            var a_ellipse = Math.Abs(points[0].X - center_ellipse.X);
            a_ellipse = a_ellipse * a_ellipse;
            var b_ellipse = Math.Abs(points[0].Y - center_ellipse.Y);
            b_ellipse = b_ellipse * b_ellipse;

            //Проверка на пересечение сторон прямоугольника выделения и эллипса
            if (PointsIntersectionEllipse(a.X, center_ellipse.Y, center_ellipse.X, a_ellipse, b_ellipse, a.Y, b.Y)) return true;
            if (PointsIntersectionEllipse(b.X, center_ellipse.Y, center_ellipse.X, a_ellipse, b_ellipse, a.Y, b.Y)) return true;
            if (PointsIntersectionEllipse(a.Y, center_ellipse.X, center_ellipse.Y, a_ellipse, b_ellipse, a.X, b.X)) return true;
            if (PointsIntersectionEllipse(b.Y, center_ellipse.X, center_ellipse.Y, a_ellipse, b_ellipse, a.X, b.X)) return true;

            //Надо ли выделять эллипс, если прямоугольник выделения находится внутри эллипса (не в центре)?
            /*
            if (a_ellipse >= b_ellipse)
            {
                var e = Math.Sqrt((1.0 - (b_ellipse) / (a_ellipse)));
                var c = a_ellipse * e;
                var FX1 = center_ellipse.X - c;
                var FX2 = center_ellipse.X + c;
                var FY = center_ellipse.Y;
                var D = a_ellipse * (3.0 - e);
                var P = Math.Sqrt(((FX1 - a.X) * (FX1 - a.X) + (FY - a.Y) * (FY - a.Y))) + Math.Sqrt(((FX2 - a.X) * (FX2 - a.X) + (FY - a.Y) * (FY - a.Y)));
                if (P <= D) return true;
            }
            else
            {
                var e = Math.Sqrt((1.0 - (a_ellipse) / (b_ellipse)));
                var c = b_ellipse * e;
                var FY1 = center_ellipse.Y - c;
                var FY2 = center_ellipse.Y + c;
                var FX = center_ellipse.X;
                var D = b_ellipse * (3.0 - e);
                var P = Math.Sqrt(((FY1 - a.Y) * (FY1 - a.Y) + (FX - a.X) * (FX - a.X))) + Math.Sqrt(((FY2 - a.Y) * (FY2 - a.Y) + (FX - a.X) * (FX - a.X)));
                if (P <= D) return true;
            }*/
            var in_ellips = ((a.X - center_ellipse.X) * (a.X - center_ellipse.X)) / a_ellipse + ((a.Y - center_ellipse.Y) * (a.Y - center_ellipse.Y)) / b_ellipse;
            if (in_ellips <= 1.0) return true;
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
            CalcBounds();
            var ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = Math.Abs(this.rightBottom.X - this.leftTop.X),
                Height = Math.Abs(this.rightBottom.Y - this.leftTop.Y),
                  Margin = new Thickness(this.leftTop.X, this.leftTop.Y, 0, 0),
                  Fill = this.FillBrush, Stroke = new SolidColorBrush(this.BoundaryColor)};
            where.DrawingSurface.Children.Add(ellipse);
            this._shapeFigure = ellipse;
        }

        #endregion
    }
}
