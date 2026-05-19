using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AutomationStep
{
    public sealed class AutomationStepViewModel : ViewModelBase
    {
        public RelayCommand GoToCustomizationStepCommand { get; }
        public RelayCommand GoToAnalyzerSettingsStepCommand { get; }

        private readonly CreateProjectDraft _draft;

        public AutomationStepViewModel(CreateProjectDraft draft, Action goToNextStepAction, Action goToPreviousStepAction)
        {
            _draft = draft;

            GoToCustomizationStepCommand = new(goToNextStepAction);
            GoToAnalyzerSettingsStepCommand = new(goToPreviousStepAction);
        }
    }
}