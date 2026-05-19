using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Features.Settings;
using CodeScope.Presentation.Features.Archive;
using System.Windows;
using CodeScope.Infrastructure.Persistence.Json;
using System.Collections.ObjectModel;
using CodeScope.Domain.Projects;

namespace CodeScope.Presentation.Features.ProjectsHub
{
    public sealed class ProjectsHubViewModel : ViewModelBase, IAsyncInitializable
    {
        public RelayCommand OpenArchiveCommand { get; }
        public RelayCommand OpenSettingsCommand { get; }
        public RelayCommand? ArchiveProjectCommand { get; }
        public RelayCommand OpenCreateProjectCommand { get; }
        public RelayCommand OpenProjectWorkspaceCommand { get; }

        public ObservableCollection<Project> Projects { get; private set; }

        private readonly JsonProjectRepository _repository;


        public ProjectsHubViewModel(IRootNavigationService rootNavigationService, JsonProjectRepository repository)
        {
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