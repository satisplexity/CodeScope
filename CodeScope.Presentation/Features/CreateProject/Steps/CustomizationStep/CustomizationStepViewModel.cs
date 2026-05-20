using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Models;

namespace CodeScope.Presentation.Features.CreateProject.Steps.CustomizationStep
{
    public sealed class CustomizationStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAnalyzerSettingsStepCommand { get; }
        
        public AsyncRelayCommand CreateProjectCommand { get; }

        private readonly CreateProjectDraftModel _draft;

        public CustomizationStepViewModel(CreateProjectDraftModel draft, Action goToNextStepAction, Func<Task> createProjectAction)
        {
            _draft = draft;

            GoToAnalyzerSettingsStepCommand = new(goToNextStepAction);
            CreateProjectCommand = new(createProjectAction);
        }
    }
}