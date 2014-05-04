using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace pmm91_vector.Misc
{
    [Serializable]
    [XmlInclude(typeof(SolidColorBrush)), XmlInclude(typeof(MatrixTransform))]
    public class FillBrushSerializator
    {
        private byte r, g, b, a;        //Разложение цвета границы
        private byte Br, Bg, Bb, Ba;    //Разложение цвета заливки

        public FillBrushSerializator()
        {
            this.OutColor = Colors.Black;
            this.FillBrush = Brushes.Black;
        }

        public FillBrushSerializator(Brush brush, Color color)
        {
            this.OutColor = color;
            this.FillBrush = brush;
        }

        public Brush FillBrush
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(Br, Bg, Bb, Ba));
            }
            set
            {
                if (value.GetType() == typeof(SolidColorBrush))
                {
                    var tmp = value as SolidColorBrush;
                    Br = tmp.Color.R;
                    Bg = tmp.Color.G;
                    Bb = tmp.Color.B;
                    Ba = tmp.Color.A;
                }
                else
                    throw new NotImplementedException("Неизвестный вид кисти");
            }
        }

        public Color OutColor
        {
            get { return Color.FromArgb(a, r, g, b); }
            set
            {
                r = value.R;
                g = value.G;
                b = value.B;
                a = value.A;
            }
        }
    }
}
