using CodeScope.Presentation.Features.ProjectWorkspace.Features.ProjectAnalysis;
using CodeScope.Presentation.Features.ProjectWorkspace.Features.ProjectSettings;
using CodeScope.Presentation.Features.ProjectWorkspace.Features.Snapshots;
using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Application.Projects.Models;

namespace CodeScope.Presentation.Features.ProjectWorkspace
{
    public sealed class ProjectWorkspaceViewModel : ViewModelBase
    {
        public AsyncRelayCommand OpenProjectHubCommand { get; }

        public ProjectModel Project { get;  }

        public IProjectWorkspaceNavigationService WorkspaceNavigation { get; }

        public AsyncRelayCommand OpenSnapshotsCommand { get; }

        public AsyncRelayCommand OpenAnalysisCommand { get; }

        public AsyncRelayCommand OpenProjectSettingsCommand { get; }

        public ProjectWorkspaceViewModel(
            IRootNavigationService rootNavigation,
            IProjectWorkspaceNavigationService workspaceNavigation,
            ProjectModel project)
        {
            Project = project;
            WorkspaceNavigation = workspaceNavigation;

            OpenProjectHubCommand = new(rootNavigation.NavigateTo<ProjectsHubViewModel>);

            OpenSnapshotsCommand = new(WorkspaceNavigation.NavigateTo<SnapshotsViewModel>);
            OpenAnalysisCommand = new(WorkspaceNavigation.NavigateTo<ProjectAnalysisViewModel>);
            OpenProjectSettingsCommand = new(WorkspaceNavigation.NavigateTo<ProjectSettingsViewModel>);

            WorkspaceNavigation.NavigateTo<SnapshotsViewModel>();
        }
    }
}