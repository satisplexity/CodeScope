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

        private ViewModelBase _overlayViewModel;

        public ViewModelBase OverlayViewModel
        {
            get => _overlayViewModel;

            private set => SetProperty(ref _overlayViewModel, value);
        }

        public bool IsOverlayOpen => OverlayViewModel is not null;

        public MainViewModel(ProjectsViewModel projectsViewModel)
        {
            projectsViewModel.ShowOverlayAction = OpenOverlay;

            CurrentViewModel = projectsViewModel;

            _ = InitializeAsync(projectsViewModel);
        }

        private async Task InitializeAsync(ProjectsViewModel projectViewModel) =>
            await projectViewModel.LoadAsync();

        private void OpenOverlay(ViewModelBase viewModel) => OverlayViewModel = viewModel;
    }
}