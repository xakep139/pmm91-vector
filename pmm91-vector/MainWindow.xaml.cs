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
          AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;
        }

        static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                var ex = e.ExceptionObject as Exception;
                MessageBox.Show(string.Format("Exception: {0}", ex.Message), "Unhandled Exception :(",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Unknown exception (maybe in unmanaged code).", "Unhandled Exception :(",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ProgramWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Misc.WindowManager.Instance.Parent = this.MainCanvas;
            Misc.WindowManager.Instance.NewWindow();
        }
    }
}
