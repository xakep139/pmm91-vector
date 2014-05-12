using System;

using pmm91_vector.Interfaces;

namespace pmm91_vector.Implementation
{
    class FigureTransform : IFigureTransform
    {
        //TODO сжатие/расширение фигуры
        public eTypeTransformation TypeTransformation { set; get; }
        public System.Windows.Media.Matrix TransformMatrix { get; set; }

        public void Move(System.Windows.Point vector)
        {
            TransformMatrix = new System.Windows.Media.Matrix(1, 0, 0, 1, vector.X, vector.Y);
            TypeTransformation = eTypeTransformation.Move;
        }

        public void Rotate(double angle)
        {
            double cos = Math.Cos(angle); 
            double sin = Math.Sin(angle);
            TransformMatrix = new System.Windows.Media.Matrix(cos, sin, -sin, cos, 0, 0);
            TypeTransformation = eTypeTransformation.Rotate;
        }

        public bool MoveMarker(Misc.Marker mark, System.Windows.Point newPoint)
        {
            throw new NotImplementedException();
        }
    }
}
