using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;
using CodeScope.Presentation.Features.Archive;
using CodeScope.Presentation.Features.CreateProject;
using CodeScope.Presentation.Features.ProjectWorkspace;
using CodeScope.Presentation.Features.Settings;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Framework.Navigation.Root;
using System.Collections.ObjectModel;
using System.Windows;

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
        private readonly IRootNavigationService _navigation;

        private Project _selectedProject;

        public Project SelectedProject
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

            ArchiveProjectCommand = new(() => MessageBox.Show("ARHIVE PROJECT"));

            OpenCreateProjectCommand = new(navigation.NavigateTo<CreateProjectViewModel>);

            OpenProjectWorkspaceCommand = new(navigation.NavigateTo<ProjectWorkspaceViewModel>);
        }

        public async Task InitializeAsync()
        {
            List<Project> projects = await _repository.GetAllProjectsAsync();

            Projects.Clear();

            foreach(Project project in projects)
                Projects.Add(project);
        }

        public void OpenProjectWorkspace()
        {

        }
    }
}
