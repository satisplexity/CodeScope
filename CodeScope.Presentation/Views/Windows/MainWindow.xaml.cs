using CodeScope.Presentation.ViewModels;
using System.Windows.Input;
using System.Windows;

namespace CodeScope.Presentation.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
            => SwitchWindowState();

        private void CloseButton_Click(object sender, RoutedEventArgs e)
            => App.Current.Shutdown();

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs mouse)
        {
            if (mouse.ClickCount == 2)
            {
                SwitchWindowState();

                return;
            }

            DragMove();
        }

        private void SwitchWindowState()
            => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }
}