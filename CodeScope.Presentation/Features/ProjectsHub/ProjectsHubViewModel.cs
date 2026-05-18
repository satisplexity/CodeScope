using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Features.Settings;
using CodeScope.Presentation.Features.Archive;
using System.Windows;

namespace CodeScope.Presentation.Features.ProjectsHub
{
    public sealed class ProjectsHubViewModel : ViewModelBase
    {
        public RelayCommand OpenArchiveCommand { get; }
        public RelayCommand OpenSettingsCommand { get; }
        public RelayCommand? ArchiveProjectCommand { get; }
        public RelayCommand OpenCreateProjectCommand { get; }
        public RelayCommand OpenProjectWorkspaceCommand { get; }

        public ProjectsHubViewModel(IRootNavigationService rootNavigationService)
        {
            OpenArchiveCommand = new(rootNavigationService.NavigateTo<ArchiveViewModel>);

            OpenSettingsCommand = new(rootNavigationService.NavigateTo<SettingsViewModel>);

            ArchiveProjectCommand = new(() => MessageBox.Show("ARHIVE PROJECT"));

            OpenCreateProjectCommand = new(rootNavigationService.NavigateTo<CreateProjectViewModel>);

            OpenProjectWorkspaceCommand = new(rootNavigationService.NavigateTo<ProjectWorkspaceViewModel>);
        }
    }
}