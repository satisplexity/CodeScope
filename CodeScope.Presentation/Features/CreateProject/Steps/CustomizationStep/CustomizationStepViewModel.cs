using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.CustomizationStep
{
    public class CustomizationStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAutomationStepCommand { get; }
        
        public CustomizationStepViewModel(Action goToNextStepAction)
        {
            GoToAutomationStepCommand = new(goToNextStepAction);
        }
    }
}