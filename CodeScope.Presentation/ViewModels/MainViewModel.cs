using CodeScope.Domain.Projects;
using CodeScope.Presentation.ViewModels.Base;

namespace CodeScope.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;

             set => SetProperty(ref _currentViewModel, value);
        }

        private ViewModelBase _overlayViewModel;

        public ViewModelBase OverlayViewModel
        {
            get => _overlayViewModel;

            private set
            {
                if (SetProperty(ref _overlayViewModel, value))
                {
                    OnPropertyChanged(nameof(IsOverlayOpen));
                }
            }
        }

        public bool IsOverlayOpen => OverlayViewModel is not null;

        public MainViewModel(StartViewModel startViewModel)
        {
            startViewModel.ShowOverlayAction = OpenOverlay;
            startViewModel.HideOverlayAction = HideOverlay;
            startViewModel.OpenProjectAction = OpenProject;

            CurrentViewModel = startViewModel;

            _ = InitializeAsync(startViewModel);
        }

        private async Task InitializeAsync(StartViewModel startViewModel)
            => await startViewModel.LoadAsync();

        private void OpenOverlay(ViewModelBase viewModel)
            => OverlayViewModel = viewModel;

        private void HideOverlay()
            => OverlayViewModel = null;

        private void OpenProject(Project project)
            => CurrentViewModel = new ProjectOverviewViewModel(project);
    }
}