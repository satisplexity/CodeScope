using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Framework.Navigation.ProjectWorkspace
{
    public class ProjectWorkspaceNavigationService : NavigationService, IProjectWorkspaceNavigationService
    {
        public ProjectWorkspaceNavigationService(ProjectWorkspaceNavigationStore store, IServiceProvider serviceProvider)
            : base(store, serviceProvider)
        {
            
        }
    }
}