using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Abstractions;
using CodeScope.Presentation.Features.Settings;
using CodeScope.Presentation.Features.Archive;
using System.Collections.ObjectModel;
using CodeScope.Domain.Projects;

namespace CodeScope.Presentation.Features.ProjectsHub
{
    public sealed class ProjectsHubViewModel : ViewModelBase, IAsyncInitializable
    {
        public AsyncRelayCommand OpenArchiveCommand { get; }
        public AsyncRelayCommand OpenSettingsCommand { get; }
        public RelayCommand? ArchiveProjectCommand { get; }
        public AsyncRelayCommand OpenCreateProjectCommand { get; }
        public AsyncRelayCommand OpenProjectWorkspaceCommand { get; }

        public ObservableCollection<Project> Projects { get; } = new();

        private readonly IProjectRepository _repository;
        private readonly IRootNavigationService _navigation;

        private Project? _selectedProject;

        public Project? SelectedProject
        {
            get => _selectedProject;
            set => SetProperty(ref _selectedProject, value);
        }

        public ProjectsHubViewModel(IRootNavigationService navigation, IProjectRepository repository)
        {
            _navigation = navigation;
            _repository = repository;

            OpenArchiveCommand = new(navigation.NavigateTo<ArchiveViewModel>);

            OpenSettingsCommand = new(navigation.NavigateTo<SettingsViewModel>);

            ArchiveProjectCommand = new(ArchiveProject);

            OpenCreateProjectCommand = new(navigation.NavigateTo<CreateProjectViewModel>);

            OpenProjectWorkspaceCommand = new(OpenProjectWorkspace);
        }

        public async Task InitializeAsync()
        {
            List<Project> projects = await _repository.GetAllProjectsAsync();

            Projects.Clear();

            foreach (Project project in projects)
                if(!project.IsArchived)
                    Projects.Add(project);
        }

        public void ArchiveProject()
        {
            if (SelectedProject is null)
                return;
            
            SelectedProject.IsArchived = true;

            Projects.Remove(SelectedProject);
        }

        public async Task OpenProjectWorkspace() =>
            await _navigation.NavigateTo<ProjectWorkspaceViewModel, Project>(SelectedProject);
    }
}