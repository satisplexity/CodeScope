using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.CreateProject.Steps.CustomizationStep
{
    public sealed class CustomizationStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAnalyzerSettingsStepCommand { get; }
        
        public RelayCommand CreateProjectCommand { get; }

        private readonly CreateProjectDraft _draft;

        public CustomizationStepViewModel(CreateProjectDraft draft, Action goToNextStepAction, Action createProjectAction)
        {
            _draft = draft;

            GoToAnalyzerSettingsStepCommand = new(goToNextStepAction);
            CreateProjectCommand = new(createProjectAction);
        }
    }
}