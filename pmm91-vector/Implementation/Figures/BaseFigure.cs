using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

        public BaseFigure(List<Point> points)
        {
            AxisX = new Point(0, 1);//Инициализируем ось Х
            SetPoints(points);
        }

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

        public Point Center { get; set; }
        public Point AxisX { get; set; }

        abstract public void Transform(Interfaces.IFigureTransform transformer);

        abstract public bool Selection(Point a, Point b);

        public void SetPoint(int index, Point p)
        {
            var globalPoints = Local2Global();
            globalPoints[index] = p;
            SetPoints(globalPoints);
        }

        abstract public Interfaces.IGeometryFigure Intersection(Interfaces.IGeometryFigure figure);

        abstract public Interfaces.IGeometryFigure Union(Interfaces.IGeometryFigure figure);

        abstract public void Draw(Panel where);

         /// <summary>
        /// Пересчитывет центр фигуры, состоящей из указанных точек
        /// </summary>
        /// <param name="points">Список точек, в глобальной системе координат</param>
        protected void InitCenter(List<Point> points)
        {
            Point center = new Point();
            foreach (var p in points)
            {
                center.X += p.X;
                center.Y += p.Y;
            }
            center.X /= points.Count;
            center.Y /= points.Count;

            Center = center;
        }

        /// <summary>
        /// Возвращет список координат точек фигуры в глобальных координатах
        /// </summary>
        protected List<Point> Local2Global()
        {
            List<Point> globalPoints = new List<Point>();

            double cosPhi = AxisX.X / Math.Sqrt(AxisX.X * AxisX.X + AxisX.Y * AxisX.Y);//Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = Math.Sqrt(1 - cosPhi * cosPhi);//Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.X, Center.Y);//Матрицы трансформации

            foreach (var p in Points)
            {
                globalPoints.Add(transformMatrix.Transform(p)); 
            }

            return globalPoints;
        }

        /// <summary>
        /// Устанавливает точки фигуры
        /// </summary>
        /// <param name="points">Список точек, в глобальной системе координат</param>
        protected void SetPoints(List<Point> points)
        {
            InitCenter(points);//Вычисляем центр

            #region Переводим точки points из глобальных координат в локальные

            Points = new List<Point>();

            double cosPhi = AxisX.X / Math.Sqrt(AxisX.X * AxisX.X + AxisX.Y * AxisX.Y);//Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = Math.Sqrt(1 - cosPhi * cosPhi);//Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.Y, Center.X);//Матрицы трансформации
            transformMatrix.Invert();

            foreach (var p in points)
            {
                Points.Add(transformMatrix.Transform(p));
            }

            #endregion
        }
    }
}
