using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        }

        #endregion

        #region IGeometryFigure

        public override bool Selection(Point a, Point b)
        {
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
            this.leftTop = new Point(Math.Min(this.Points[0].X, this.Points[1].X),
                                     Math.Min(this.Points[0].Y, this.Points[1].Y));
            this.rightBottom = new Point(Math.Max(this.Points[0].X, this.Points[1].X),
                                     Math.Max(this.Points[0].Y, this.Points[1].Y));
            //TODO: учесть локальную ось X
            var ellipse = new System.Windows.Shapes.Ellipse 
                { Width = Math.Abs(rightBottom.X - leftTop.X), Height = Math.Abs(rightBottom.Y - leftTop.Y),
                  Margin = new Thickness(this.Center.X + this.leftTop.X, this.Center.Y + this.leftTop.Y, 0, 0),
                  Fill = this.FillBrush, Stroke = new SolidColorBrush(this.BoundaryColor)};
            where.DrawingSurface.Children.Add(ellipse);
            this._shapeFigure = ellipse;
        }

        #endregion
    }
}
