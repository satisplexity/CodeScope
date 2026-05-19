using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AutomationStep
{
    public class AutomationStepViewModel : ViewModelBase
    {
        public RelayCommand GoToCustomizationStepCommand { get; }
        public RelayCommand GoToAnalyzerSettingsStepCommand { get; }

        public AutomationStepViewModel(Action goToNextStepAction, Action goToPreviousStepAction)
        {
            GoToCustomizationStepCommand = new(goToNextStepAction);
            GoToAnalyzerSettingsStepCommand = new(goToPreviousStepAction);
        }
    }
}