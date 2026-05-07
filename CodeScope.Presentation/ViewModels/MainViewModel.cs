using CodeScope.Presentation.ViewModels.Base;

namespace CodeScope.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;

            private set => SetProperty(ref _currentViewModel, value);
        }

        public MainViewModel(ProjectsViewModel projectViewModel)
        {
            CurrentViewModel = projectViewModel;
        }
    }
}