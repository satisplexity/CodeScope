using CodeScope.Application.Projects.Abstractions;
using CodeScope.Presentation.ViewModels.Base;
using CodeScope.Domain.Projects;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CodeScope.Presentation.Commands;

namespace CodeScope.Presentation.ViewModels
{
    public class ProjectsViewModel : ViewModelBase
    {
        private readonly IProjectRepository _projectRepository;

        public ObservableCollection<Project> Projects { get; } = [];

        public ICommand CreateProjecrtCommand { get; }

        public ProjectsViewModel(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            CreateProjecrtCommand = new RelayCommand(CreateProject);
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
    }
}