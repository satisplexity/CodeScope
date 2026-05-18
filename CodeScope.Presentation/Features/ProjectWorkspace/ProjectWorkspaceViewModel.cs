using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.ProjectWorkspace
{
    public sealed class ProjectWorkspaceViewModel : ViewModelBase
    {
        public RelayCommand OpenProjectHubCommand { get; }
        
        public ProjectWorkspaceViewModel(IRootNavigationService navigation)
        {
            OpenProjectHubCommand = new(navigation.NavigateTo<ProjectsHubViewModel>);
        }
    }
}