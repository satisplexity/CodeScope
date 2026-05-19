using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AnalyzerSettingsStep
{
    public sealed class AnalyzerSettingsStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAutomationStepCommand { get; }

        public RelayCommand GoToGeneralInfoStepCommand { get; }

        private readonly CreateProjectDraft _draft;

        public AnalyzerSettingsStepViewModel(CreateProjectDraft draft, Action goToNextStepAction, Action goToPreviosStepAction)
        {
            _draft = draft;

            GoToAutomationStepCommand = new(goToNextStepAction);
            GoToGeneralInfoStepCommand = new(goToPreviosStepAction);
        }
    }
}
