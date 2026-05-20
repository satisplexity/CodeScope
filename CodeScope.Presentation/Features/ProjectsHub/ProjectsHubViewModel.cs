using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Abstractions;
using CodeScope.Presentation.Features.Settings;
using CodeScope.Presentation.Features.Archive;
using CodeScope.Application.Projects.Models;
using CodeScope.Application.Projects.Mappers;
using System.Collections.ObjectModel;

namespace CodeScope.Presentation.Features.ProjectsHub
{
    public sealed class ProjectsHubViewModel : ViewModelBase, IAsyncInitializable
    {
        public AsyncRelayCommand OpenArchiveCommand { get; }
        public AsyncRelayCommand OpenSettingsCommand { get; }
        public AsyncRelayCommand ArchiveProjectCommand { get; }
        public AsyncRelayCommand OpenCreateProjectCommand { get; }
        public AsyncRelayCommand OpenProjectWorkspaceCommand { get; }

        public ObservableCollection<ProjectModel> Projects { get; } = new();

        private readonly IProjectRepository _repository;
        private readonly IRootNavigationService _navigation;

        private ProjectModel? _selectedProject;

        public ProjectModel? SelectedProject
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
            List<ProjectModel> projects = ProjectMapper.ToModel(await _repository.GetAllProjectsAsync());

            Projects.Clear();

            foreach (ProjectModel project in projects)
                if(!project.IsArchived)
                    Projects.Add(project);
        }

        public async Task ArchiveProject()
        {
            if (SelectedProject is null)
                return;

            await _repository.ArchiveAsync(SelectedProject.Id);

            Projects.Remove(SelectedProject);
        }

        public async Task OpenProjectWorkspace()
        {
            if (SelectedProject is null) return;

            await _navigation.NavigateTo<ProjectWorkspaceViewModel, ProjectModel>(SelectedProject);
        }
    }
}