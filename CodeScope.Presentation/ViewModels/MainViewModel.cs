using CodeScope.Domain.Projects;
using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.ViewModels
{
    public enum TransitionState
    {
        None,
        FadeIn,
        FadeOut,
    }

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

        private TransitionState _transitionState = TransitionState.None;

        public TransitionState TransitionState
        {
            get => _transitionState;
            set => SetProperty(ref _transitionState, value);
        }

        public bool IsOverlayOpen => OverlayViewModel is not null;

        public MainViewModel(StartViewModel startViewModel)
        {
            startViewModel.OpenProjectAction = OpenProject;
            //startViewModel.SwitchViewAction = SwitchView;
            //startViewModel.GoToLastViewAction = GoToLastView;

            //SwitchView(startViewModel);

            _ = InitializeAsync(startViewModel);
        }

        private async Task InitializeAsync(StartViewModel startViewModel)
            => await startViewModel.LoadAsync();

        private void SwitchView(ViewModelBase viewModel)
        {
            _ = AnimateTrasition(viewModel);
        }

        private async Task AnimateTrasition(ViewModelBase viewModel)
        {

            await Task.Delay(60);

           _lastViewModel = CurrentViewModel;

            TransitionState = TransitionState.FadeOut;


            CurrentViewModel = viewModel;

            TransitionState = TransitionState.FadeIn;
        }

        private void GoToLastView()
        {
            if (_lastViewModel is not null)
            {
                SwitchView(_lastViewModel);
            }
        }

        private void OpenProject(Project project)
        {
            //SwitchView(new ProjectOverviewViewModel(project));
        }
    }
}