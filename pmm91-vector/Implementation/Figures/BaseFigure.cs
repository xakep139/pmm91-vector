using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Базовый класс для всех фигур
    /// </summary>
    [Serializable]
    public abstract class BaseFigure : Interfaces.IFigure
    {
        private int z;
        private IList<Point> points = new List<Point>();
        private FillBrushSerializator _fillBrushSerializer = new FillBrushSerializator(Brushes.White, Colors.Black);

        /// <summary>
        /// Конструктор без параметров (по умолчанию)
        /// </summary>
        public BaseFigure() { }

        public BaseFigure(IEnumerable<Point> points)
        {
            AxisX = new Point(1, 0);    //Инициализируем ось Х
            SetPoints(points);
        }

        public Color BoundaryColor
        {
            get { return this._fillBrushSerializer.OutColor; }
            set { this._fillBrushSerializer.OutColor = value; }
        }

        public FillBrushSerializator FillBrushSerializer
        {
            get { return this._fillBrushSerializer; }
            set { this._fillBrushSerializer = value; }
        }

        public Brush FillBrush
        {
            get { return this._fillBrushSerializer.FillBrush; }
            set { this._fillBrushSerializer.FillBrush = value; }
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

        private Point _axisX = new Point(1,0);
        public Point AxisX 
        {
            get { return _axisX; }
            set
            {
                var norma = Math.Sqrt(value.X * value.X + value.Y * value.Y);
                _axisX = new Point(value.X / norma, value.Y / norma);
            }
        }

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
            double cosPhi = AxisX.X; //Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = -AxisX.Y; //Синус ула поворота
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

            double cosPhi = AxisX.X; //Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = -AxisX.Y; //Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.X, Center.Y);   //Матрицы трансформации
            transformMatrix.Invert();

            foreach (var p in points)
                Points.Add(transformMatrix.Transform(p));

            #endregion
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
