using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.GeneralInfoStep
{
    public class GeneralInfoStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAnalyzerSettingStepCommand { get; }

        public GeneralInfoStepViewModel(Action goToNextStepAction)
        {
            GoToAnalyzerSettingStepCommand = new(goToNextStepAction);
        }
    }
}
