using CodeScope.Domain.Projects;
using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.ProjectWorkspace
{
    public sealed class ProjectWorkspaceViewModel : ViewModelBase
    {
        public RelayCommand OpenProjectHubCommand { get; }

        private readonly Project _project;

        public ProjectWorkspaceViewModel(IRootNavigationService navigation, Project project)
        {
            _project = project;

            OpenProjectHubCommand = new(navigation.NavigateTo<ProjectsHubViewModel>);
        }
    }
}