using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

using pmm91_vector.Interfaces;
using pmm91_vector.Implementation.Figures;

namespace pmm91_vector.Implementation
{
    /// <summary>
    /// Класс реализующий интерфейс графики
    /// </summary>
    public class Graphics : IGraphics
    {
        private System.Windows.Controls.Canvas drawingCanvas;

        public void Init(System.Windows.Media.Visual displayContext)
        {
            //DrawingContext drawingContext = ((DrawingVisual)displayContext).RenderOpen();
            //Rect rect = new Rect(new System.Windows.Point(160, 100), new System.Windows.Size(320, 80));
            //drawingContext.DrawRectangle(System.Windows.Media.Brushes.LightBlue, (System.Windows.Media.Pen)null, rect);
            //drawingContext.Close();
        }

        public void Init(System.Windows.Controls.Canvas displayCanvas)
        {
            drawingCanvas = displayCanvas;
        }

        public void Paint(IFigureCollection displayScene)
        {
            drawingCanvas.Children.Clear();
            foreach (BaseFigure figure in displayScene)
            {
                if (figure.GetType() == typeof(pmm91_vector.Implementation.Figures.Polygon))
                {
                    System.Windows.Shapes.Polygon polygon = new System.Windows.Shapes.Polygon();
                    
                    if (figure.Points.Count == 2) // Прямоугольник по 2-м точкам
                    {
                        polygon.Points.Add(new Point(figure.Points[0].X + figure.Center.X, figure.Points[0].Y + figure.Center.Y));
                        polygon.Points.Add(new Point(figure.Points[1].X + figure.Center.X, figure.Points[0].Y + figure.Center.Y));
                        polygon.Points.Add(new Point(figure.Points[1].X + figure.Center.X, figure.Points[1].Y + figure.Center.Y));
                        polygon.Points.Add(new Point(figure.Points[0].X + figure.Center.X, figure.Points[1].Y + figure.Center.Y));

                        //TODO: цвет линии
                        polygon.Stroke = SystemColors.WindowFrameBrush;
                        drawingCanvas.Children.Add(polygon);
                    }
                }
            }
        }

        public void Free_mem(System.Windows.Media.Visual displayContext)
        {
            throw new NotImplementedException();
        }
    }
}
