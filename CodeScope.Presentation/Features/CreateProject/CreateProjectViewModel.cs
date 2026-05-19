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

        public CreateProjectViewModel(IRootNavigationService navigation)
        {
            GoBackCommand = new(navigation.GoBack);

            _steps = new ViewModelBase[]
            {
                new GeneralInfoStepViewModel(GoToNextStep),
                new AnalyzerSettingsStepViewModel(GoToNextStep, GoToPreviousStep),
                new AutomationStepViewModel(GoToNextStep, GoToPreviousStep),
                new CustomizationStepViewModel(GoToPreviousStep)
            };
        }

        public void GoToNextStep() =>
            CurrentStep = _steps[++_currentStepIndex];

        public void GoToPreviousStep() =>
            CurrentStep = _steps[--_currentStepIndex];
    }
}