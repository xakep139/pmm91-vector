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
            var leftTopSel = new Point(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
            var rightBottomSel = new Point(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
            CalcBounds();
            return ((leftTopSel.X <= this.leftTop.X) && 
                    (rightBottomSel.X >= this.rightBottom.X) && 
                    (leftTopSel.Y <= this.leftTop.Y) && 
                    (rightBottomSel.Y >= this.rightBottom.Y));
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
