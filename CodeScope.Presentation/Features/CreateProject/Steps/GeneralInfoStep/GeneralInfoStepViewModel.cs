using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.GeneralInfoStep
{
    public sealed class GeneralInfoStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAnalyzerSettingStepCommand { get; }

        private readonly CreateProjectDraft _draft;

        public GeneralInfoStepViewModel(CreateProjectDraft draft, Action goToNextStepAction)
        {
            _draft = draft;

            GoToAnalyzerSettingStepCommand = new(goToNextStepAction);
        }
    }
}
