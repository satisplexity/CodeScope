using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AutomationStep
{
    public class AutomationStepViewModel : ViewModelBase
    {
        public RelayCommand GoToCusomizationStepCommand { get; }
        public RelayCommand GoToAnalyzerSettingsStepCommand { get; }

        public AutomationStepViewModel(Action goToNextStepAction, Action goToPreviousStepAction)
        {
            GoToCusomizationStepCommand = new(goToNextStepAction);
            GoToAnalyzerSettingsStepCommand = new(goToPreviousStepAction);
        }
    }
}