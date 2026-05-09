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

        public MainViewModel(ProjectsViewModel projectsViewModel)
        {

            projectsViewModel.ShowOverlayAction = OpenOverlay;
            projectsViewModel.HideOverlayAction = HideOverlay;
            projectsViewModel.OpenProjectAction = OpenProject;

            CurrentViewModel = projectsViewModel;

            _ = InitializeAsync(projectsViewModel);
        }

        private async Task InitializeAsync(ProjectsViewModel projectViewModel) =>
            await projectViewModel.LoadAsync();

        private void OpenOverlay(ViewModelBase viewModel) => OverlayViewModel = viewModel;

        private void HideOverlay() => OverlayViewModel = null;

        private void OpenProject(Project project)
        {
            CurrentViewModel = new ProjectOverviewViewModel(project);
        }
    }
}