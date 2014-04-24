using System;
using System.Windows.Media;
using System.Drawing.Drawing2D;

namespace pmm91_vector.Misc
{
    [Serializable]
    public class FillBrushSerializator
    {
        private byte r, g, b, a;        //Разложение цвета границы
        private byte Br, Bg, Bb, Ba;    //Разложение цвета заливки
        private HatchStyle hatchStyle;
        private bool isSolidBrush;

        public bool IsSolidBrush
        {
            get
            {
                return this.isSolidBrush;
            }
            set
            {
                this.isSolidBrush = value;
            }
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
                if (IsSolidBrush)
                    return new SolidColorBrush(Color.FromArgb(Br, Bg, Bb, Ba));
                else
                    return (Brush)(Object)new HatchBrush(hatchStyle, System.Drawing.Color.FromArgb(Br, Bg, Bb, Ba));
            }
            set
            {
                if (value.GetType() == typeof(SolidColorBrush))
                {
                    IsSolidBrush = true;
                    var tmp = value as SolidColorBrush;
                    Br = tmp.Color.R;
                    Bg = tmp.Color.G;
                    Bb = tmp.Color.B;
                    Ba = tmp.Color.A;
                }
                else
                    if (value.GetType() == typeof(HatchBrush))
                    {
                        //TODO: можно сохранять и цвет штрихов
                        IsSolidBrush = false;
                        var tmp = (HatchBrush)(Object)value;
                        Br = tmp.BackgroundColor.R;
                        Bg = tmp.BackgroundColor.G;
                        Bb = tmp.BackgroundColor.B;
                        Ba = tmp.BackgroundColor.A;
                        hatchStyle = tmp.HatchStyle;
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
