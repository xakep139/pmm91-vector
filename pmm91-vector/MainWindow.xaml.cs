using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using pmm91_vector.Implementation;

namespace pmm91_vector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Graphics graphics;
        public FigureCollection figures;

        public MainWindow()
        {
            InitializeComponent();

            //TODO: исправить с целью поддержки многооконности
            graphics = new Graphics();
            graphics.Init(this.MainCanvas);

            figures = new FigureCollection();
        }
    }
}
