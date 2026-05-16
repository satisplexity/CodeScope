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

        private ViewModelBase _lastViewModel = null;

        public bool IsOverlayOpen => OverlayViewModel is not null;

        public MainViewModel(StartViewModel startViewModel)
        {
            startViewModel.OpenProjectAction = OpenProject;
            startViewModel.SwitchViewAction = SwitchView;
            startViewModel.GoToLastViewAction = GoToLastView;

            CurrentViewModel = startViewModel;

            _ = InitializeAsync(startViewModel);
        }

        private async Task InitializeAsync(StartViewModel startViewModel)
            => await startViewModel.LoadAsync();

        private void SwitchView(ViewModelBase viewModel)
        {
            _lastViewModel = CurrentViewModel;
            CurrentViewModel = viewModel;
        }

        private void GoToLastView()
        {
            if (_lastViewModel is not null)
            {
                SwitchView(_lastViewModel);
            }
        }

        private void OpenProject(Project project)
            => CurrentViewModel = new ProjectOverviewViewModel(project);
    }
}