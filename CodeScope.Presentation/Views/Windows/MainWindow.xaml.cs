using CodeScope.Presentation.ViewModels;
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
    }
}