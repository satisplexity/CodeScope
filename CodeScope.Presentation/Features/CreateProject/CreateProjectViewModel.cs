using CodeScope.Presentation.Features.CreateProject.Steps.AnalyzerSettingsStep;
using CodeScope.Presentation.Features.CreateProject.Steps.CustomizationStep;
using CodeScope.Presentation.Features.CreateProject.Steps.GeneralInfoStep;
using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Services;
using CodeScope.Domain.Projects;

namespace CodeScope.Presentation.Features.CreateProject
{
    public sealed class CreateProjectViewModel : ViewModelBase
    {
        public AsyncRelayCommand GoBackCommand { get; }

        private ViewModelBase? _currentStep;
        public ViewModelBase? CurrentStep
        {
            get => _currentStep;
            set => SetProperty(ref _currentStep, value);
        }

        private int _currentStepIndex = 0;

        private readonly ViewModelBase[] _steps;

        private readonly CreateProjectDraft _draft = new CreateProjectDraft();

        private readonly CreateProjectService _createProjectService;

        private readonly IRootNavigationService _navigation;

        public CreateProjectViewModel(IRootNavigationService navigation, CreateProjectService createProjectService)
        {
            _navigation = navigation;
            _createProjectService = createProjectService;

            GoBackCommand = new(navigation.GoBack);

            _steps =
            [
                new GeneralInfoStepViewModel(_draft, GoToNextStep),
                new AnalyzerSettingsStepViewModel(_draft, GoToNextStep, GoToPreviousStep),
                new CustomizationStepViewModel(_draft, GoToPreviousStep, CreateProject)
            ];

            CurrentStep = _steps[0];
        }

        public void GoToNextStep() =>
            CurrentStep = _steps[++_currentStepIndex];

        public void GoToPreviousStep() =>
            CurrentStep = _steps[--_currentStepIndex];

        public async Task CreateProject()
        {
            Project project = await _createProjectService.ExecuteAsync(_draft);

            await _navigation.NavigateTo<ProjectWorkspaceViewModel, Project>(project);
        }
    }
}