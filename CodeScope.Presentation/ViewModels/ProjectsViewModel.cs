using CodeScope.Application.Projects.Abstractions;
using CodeScope.Presentation.ViewModels.Base;
using CodeScope.Domain.Projects;

using System.Collections.ObjectModel;
using System.Diagnostics;
using CodeScope.Presentation.Commands;

namespace CodeScope.Presentation.ViewModels
{
    public class ProjectsViewModel : ViewModelBase
    {
        private readonly IProjectRepository _projectRepository;

        public ObservableCollection<Project> Projects { get; } = [];

        public RelayCommand CreateProjectCommand { get; }
        public RelayCommand DeleteProjectCommand { get; }

        private Project? _selectedProject;

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                if(SetProperty(ref _selectedProject, value))
                {
                    DeleteProjectCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ProjectsViewModel(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            CreateProjectCommand = new RelayCommand(CreateProject);
            DeleteProjectCommand = new RelayCommand(DeleteProject, CanDeleteProject);
        }

        public async Task LoadAsync()
        {
            List<Project> projects = await _projectRepository.GetAllProjectsAsync();

            Projects.Clear();

            foreach(Project project in projects)
            {
                Projects.Add(project);
            }

            Debug.WriteLine("Projects loaded");
        }

        private async void CreateProject()
        {
            Debug.WriteLine("CREATE PROJECT CLICKED");

            ShowOverlay(new CreateProjectViewModel());

            Project project = new()
            {
                Id = Guid.NewGuid(),
                Name = $"Test Project {DateTime.Now.Date}/{DateTime.Now.Microsecond}",
                RootPath=@"P:\CodeScope",
                CreatedAt = DateTime.Now
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();

            Projects.Add(project);
        }

        private bool CanDeleteProject() => SelectedProject is not null;

        private async void DeleteProject()
        {
            if(SelectedProject is null)
            {
                return;
            }

            await _projectRepository.DeleteAsync(SelectedProject.Id);
            await _projectRepository.SaveChangesAsync();

            Projects.Remove(SelectedProject);
        }
    }
}