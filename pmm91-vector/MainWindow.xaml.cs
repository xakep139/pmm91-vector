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
            Misc.WindowManager.Instance.Parent = this.MainCanvas;
            Misc.WindowManager.Instance.MainWindow = this;
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;
        }

        static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                var ex = e.ExceptionObject as Exception;
                MessageBox.Show(string.Format("Исключение: {0}", ex.Message), "Необработанное исключение",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Неизвестное исключение (возможно, в неуправляемом коде).",
                    "Необработанное исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
