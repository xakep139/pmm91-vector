using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;

using pmm91_vector.Misc;

namespace pmm91_vector.Implementation.Figures
{
    /// <summary>
    /// Базовый класс для всех фигур
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Ellipse)), XmlInclude(typeof(Polygon)), XmlInclude(typeof(Polyline))]
    public abstract class BaseFigure : Interfaces.IFigure, ICloneable
    {
        private int z;
        private Point _axisX = new Point(1, 0);
        private IList<Point> points = new List<Point>();
        private FillBrushSerializator _fillBrushSerializer = new FillBrushSerializator(Brushes.White, Colors.Black);

        [NonSerialized]
        protected Shape _shapeFigure = null;

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

        [XmlIgnore]
        public IList<Point> Points
        {
            get { return this.points; }
            protected set { this.points = value; }
        }

        public List<Point> PointsSerialize
        {
            get { return this.points as List<Point>; }
            protected set { this.points = value; }
        }

        public Point Center { get; set; }

        public Point AxisX 
        {
            get { return _axisX; }
            set
            {
                var norm = Math.Sqrt(value.X * value.X + value.Y * value.Y);
                _axisX = new Point(value.X / norm, value.Y / norm);
            }
        }

        public void SetPoint(int index, Point p)
        {
            var globalPoints = Local2Global();
            globalPoints[index] = p;
            SetPoints(globalPoints);
        }

        public void Transform(Interfaces.IFigureTransform transformer)
        {
            //TODO: сжатие/расширение фигуры
            switch (transformer.TypeTransformation)
            {
                case Interfaces.eTypeTransformation.Move:
                    Center = transformer.TransformMatrix.Transform(Center);
                    break;
                case Interfaces.eTypeTransformation.Rotate:
                    AxisX = transformer.TransformMatrix.Transform(AxisX);
                    break;
                case Interfaces.eTypeTransformation.Transform:
                    break;
            }
        }

        abstract public bool Selection(Point a, Point b);

        abstract public Interfaces.IGeometryFigure Intersection(Interfaces.IGeometryFigure figure);

        abstract public Interfaces.IGeometryFigure Union(Interfaces.IGeometryFigure figure);

        abstract public void Draw(Interfaces.IGraphics where);

        abstract public object Clone();

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
            double cosPhi = AxisX.X;    //Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = -AxisX.Y;   //Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.X, Center.Y);   //Матрицы трансформации

            foreach (var p in Points)
                globalPoints.Add(transformMatrix.Transform(p));

            return globalPoints;
        }

        /// <summary>
        /// Переводим точки points из глобальных координат в локальные
        /// </summary>
        protected List<Point> Global2Local(IEnumerable<Point> points)
        {
            var pointsLocal = new List<Point>();

            double cosPhi = AxisX.X; //Косинус угла поворота (угол между локальной осью Х и глобальной)
            double sinPhi = -AxisX.Y; //Синус ула поворота
            Matrix transformMatrix = new Matrix(cosPhi, sinPhi, -sinPhi, cosPhi, Center.X, Center.Y);   //Матрицы трансформации
            transformMatrix.Invert();

            foreach (var p in points)
                pointsLocal.Add(transformMatrix.Transform(p));

            return pointsLocal;
        }

        /// <summary>
        /// Устанавливает точки фигуры
        /// </summary>
        /// <param name="points">Коллекция точек (в глобальной системе координат)</param>
        protected void SetPoints(IEnumerable<Point> points)
        {
            InitCenter(points); //Вычисляем центр
            Points = Global2Local(points);
        }

        /// <summary>
        /// Определяет пересекаются ли два отрезка, заданные точками Р1Р2 и Р3Р4
        /// </summary>
        protected bool LinesIntersection(Point p1, Point p2, Point p3, Point p4)
        {
            var vect1 = p2 - p1;
            var vect2 = p2 - p3;
            var z1 = vect1.X * vect2.Y - vect1.Y * vect2.X;//z-компонента векторного произведения vect1 и vect2
            vect2 = p2 - p4;
            var z2 = vect1.X * vect2.Y - vect1.Y * vect2.X;
            //Если z1*z2<0, значит точки р3 и р4 лежат по разные стороны отрезка р1р2
            if (z1 * z2 > 0)
                return false;

            vect1 = p4 - p3;
            vect2 = p4 - p1;
            var z3 = vect1.X * vect2.Y - vect1.Y * vect2.X;
            vect2 = p4 - p2;
            var z4 = vect1.X * vect2.Y - vect1.Y * vect2.X;
            //Если z3*z4<0, значит точки р1 и р2 лежат по разные стороны отрезка р3р4

            return z1 * z2 <= 0 && z3 * z4 <= 0;
        }

        protected bool PointsIntersectionEllipse(double line, double x1, double x2, double a, double b, double left, double right)
        {
            double temp_intersec = a - a * (line - x2) * (line - x2) / b;
            temp_intersec = Math.Sqrt(temp_intersec);
            var intersec1 = x1 + temp_intersec;
            var intersec2 = x1 - temp_intersec;
            if (left >= right) { var tempor = right; right = left; left = tempor; }
            if (left <= intersec1 && intersec1 <= right) return true;
            if (left <= intersec2 && intersec2 <= right) return true;
            return false;
        }
    }
}
