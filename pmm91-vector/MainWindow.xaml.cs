using System;
using System.Windows;

namespace pmm91_vector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProgramWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Misc.WindowManager.Instance.Parent = this.MainCanvas;
            Misc.WindowManager.Instance.NewWindow();
        }
    }
}
