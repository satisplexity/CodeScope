using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Abstractions;
using System.Collections.ObjectModel;
using CodeScope.Domain.Projects;

namespace CodeScope.Presentation.Features.Archive
{
    public sealed class ArchiveViewModel : ViewModelBase, IAsyncInitializable
    {
        public AsyncRelayCommand GoBackCommand { get; }

        public AsyncRelayCommand DeleteProjectCommand { get; }

        public AsyncRelayCommand RestoreProjectCommand { get; }

        public ObservableCollection<Project> Projects { get; } = [];

        private readonly IProjectRepository _repository;

        private Project? _selectedProject;
        public Project? SelectedProject
        {
            get => _selectedProject;
            set => SetProperty(ref _selectedProject, value);
        }

        public ArchiveViewModel(IRootNavigationService navigation, IProjectRepository repository)
        {
            _repository = repository;

            GoBackCommand = new(navigation.GoBack);

            DeleteProjectCommand = new(DeleteProject);
            RestoreProjectCommand = new(RestoreProject);
        }

        public async Task InitializeAsync()
        {
            List<Project> projects = await _repository.GetAllProjectsAsync();

            Projects.Clear();

            foreach (Project project in projects)
                if (project.IsArchived)
                    Projects.Add(project);
        }

        public async Task DeleteProject()
        {
            if (SelectedProject is null)
                return;
            
            await _repository.DeleteAsync(SelectedProject.Id);
            await _repository.SaveChangesAsync();
            
            Projects.Remove(SelectedProject);
        }

        public async Task RestoreProject()
        {
            if(SelectedProject is null)
                return;

            SelectedProject.IsArchived = false;
            
            Projects.Remove(SelectedProject);
            await _repository.SaveChangesAsync();
        }
    }
}