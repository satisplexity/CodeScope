using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AnalyzerSettingsStep
{
    public class AnalyzerSettingsStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAutomationStepCommand { get; }

        public RelayCommand GoToGeneralInfoStepCommand { get; }

        public AnalyzerSettingsStepViewModel(Action goToNextStepAction, Action goToPreviosStepAction)
        {
            GoToAutomationStepCommand = new(goToNextStepAction);
            GoToGeneralInfoStepCommand = new(goToPreviosStepAction);
        }
    }
}
