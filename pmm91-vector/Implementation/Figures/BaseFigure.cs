using System;
using System.Collections.Generic;
using System.Linq;
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
        private Brush fillBrush;
        private Color boundaryColor;
        private IList<Point> points = new List<Point>();

        public BaseFigure(IEnumerable<Point> points)
        {
            AxisX = new Point(0, 1);    //Инициализируем ось Х
            SetPoints(points);
        }

        public Color BoundaryColor
        {
            get { return this.boundaryColor; }
            set { this.boundaryColor = value; }
        }

        public Brush FillBrush
        {
            get { return this.fillBrush; }
            set { this.fillBrush = value; }
        }

        public int Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public IList<Point> Points
        {
            get { return this.points; }
            protected set { this.points = value; }
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

        abstract public void Draw(Interfaces.IGraphics where);

         /// <summary>
        /// Пересчитывет центр фигуры, состоящей из указанных точек
        /// </summary>
        /// <param name="points">Коллекция точек, в глобальной системе координат</param>
        protected void InitCenter(IEnumerable<Point> points)
        {
            Point center = new Point();
            foreach (var p in points)
            {
                center.X += p.X;
                center.Y += p.Y;
            }
            center.X /= points.Count();
            center.Y /= points.Count();

            Center = center;
        }

        /// <summary>
        /// Возвращет список координат точек фигуры в глобальных координатах
        /// </summary>
        protected List<Point> Local2Global()
        {
            List<Point> globalPoints = new List<Point>();

            double cosPhi = AxisX.X / Math.Sqrt(AxisX.X * AxisX.X + AxisX.Y * AxisX.Y); //Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = Math.Sqrt(1 - cosPhi * cosPhi); //Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.X, Center.Y);   //Матрицы трансформации

            foreach (var p in Points)
                globalPoints.Add(transformMatrix.Transform(p));

            return globalPoints;
        }

        /// <summary>
        /// Устанавливает точки фигуры
        /// </summary>
        /// <param name="points">Коллекция точек (в глобальной системе координат)</param>
        protected void SetPoints(IEnumerable<Point> points)
        {
            InitCenter(points);//Вычисляем центр

            #region Переводим точки points из глобальных координат в локальные

            Points = new List<Point>();

            double cosPhi = AxisX.X / Math.Sqrt(AxisX.X * AxisX.X + AxisX.Y * AxisX.Y); //Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = Math.Sqrt(1 - cosPhi * cosPhi); //Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.Y, Center.X);   //Матрицы трансформации
            transformMatrix.Invert();

            foreach (var p in points)
                Points.Add(transformMatrix.Transform(p));

            #endregion
        }
    }
}
