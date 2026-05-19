using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Features.Settings;
using CodeScope.Presentation.Features.Archive;
using System.Windows;
using System.Collections.ObjectModel;
using CodeScope.Domain.Projects;
using CodeScope.Application.Projects.Abstractions;

namespace CodeScope.Presentation.Features.ProjectsHub
{
    public sealed class ProjectsHubViewModel : ViewModelBase, IAsyncInitializable
    {
        public RelayCommand OpenArchiveCommand { get; }
        public RelayCommand OpenSettingsCommand { get; }
        public RelayCommand? ArchiveProjectCommand { get; }
        public RelayCommand OpenCreateProjectCommand { get; }
        public RelayCommand OpenProjectWorkspaceCommand { get; }

        public ObservableCollection<Project> Projects { get; } = new();

        private readonly IProjectRepository _repository;

        public ProjectsHubViewModel(IRootNavigationService rootNavigationService, IProjectRepository repository)
        {
            _repository = repository;

            OpenArchiveCommand = new(rootNavigationService.NavigateTo<ArchiveViewModel>);

            OpenSettingsCommand = new(rootNavigationService.NavigateTo<SettingsViewModel>);

            ArchiveProjectCommand = new(() => MessageBox.Show("ARHIVE PROJECT"));

            OpenCreateProjectCommand = new(rootNavigationService.NavigateTo<CreateProjectViewModel>);

            OpenProjectWorkspaceCommand = new(rootNavigationService.NavigateTo<ProjectWorkspaceViewModel>);
        }

        public async Task InitializeAsync()
        {
            List<Project> projects = await _repository.GetAllProjectsAsync();

            Projects.Clear();

            foreach(Project project in projects)
                Projects.Add(project);
        }
    }
}
