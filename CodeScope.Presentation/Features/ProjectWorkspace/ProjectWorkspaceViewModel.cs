using CodeScope.Domain.Projects;
using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.ProjectWorkspace
{
    public sealed class ProjectWorkspaceViewModel : ViewModelBase
    {
        public AsyncRelayCommand OpenProjectHubCommand { get; }

        public Project Project { get;  }

        public ProjectWorkspaceViewModel(IRootNavigationService navigation, Project project)
        {
            Project = project;

            OpenProjectHubCommand = new(navigation.NavigateTo<ProjectsHubViewModel>);
        }
    }
}