using CodeScope.Presentation.ViewModels.Base;
using CodeScope.Presentation.Views;
using System.Windows.Controls;

namespace CodeScope.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get => _currentView;

            private set => SetProperty(ref _currentView, value);        }

        public MainViewModel()
        {
            CurrentView = new ProjectsView();
        }
    }
}