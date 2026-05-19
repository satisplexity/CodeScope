using CodeScope.Presentation.Features.CreateProject.Steps.GeneralInfoStep;
using CodeScope.Presentation.Features.CreateProject.Steps.AnalyzerSettingsStep;
using CodeScope.Presentation.Features.CreateProject.Steps.AutomationStep;
using CodeScope.Presentation.Features.CreateProject.Steps.CustomizationStep;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.CreateProject
{
    public sealed class CreateProjectViewModel : ViewModelBase
    {
        public RelayCommand GoBackCommand { get; }

        private ViewModelBase _currentStep;
        public ViewModelBase CurrentStep
        {
            get => _currentStep;
            set => SetProperty(ref _currentStep, value);
        }

        private int _currentStepIndex = 0;

        private readonly ViewModelBase[] _steps;

        private readonly CreateProjectDraft _draft = new CreateProjectDraft();

        public CreateProjectViewModel(IRootNavigationService navigation)
        {
            GoBackCommand = new(navigation.GoBack);

            _steps = new ViewModelBase[]
            {
                new GeneralInfoStepViewModel(_draft, GoToNextStep),
                new AnalyzerSettingsStepViewModel(_draft, GoToNextStep, GoToPreviousStep),
                new AutomationStepViewModel(_draft, GoToNextStep, GoToPreviousStep),
                new CustomizationStepViewModel(_draft, GoToPreviousStep, CreateProject)
            };

            CurrentStep = _steps[0];
        }

        public void GoToNextStep() =>
            CurrentStep = _steps[++_currentStepIndex];

        public void GoToPreviousStep() =>
            CurrentStep = _steps[--_currentStepIndex];

        public void CreateProject()
        {
            // CREATE PROJECT
            // NAVIGATE TO WORKSPACE
        }
    }
}