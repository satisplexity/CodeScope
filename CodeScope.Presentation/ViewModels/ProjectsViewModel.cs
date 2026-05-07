using CodeScope.Application.Projects.Abstractions;
using CodeScope.Presentation.ViewModels.Base;
using CodeScope.Domain.Projects;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CodeScope.Presentation.ViewModels
{
    public class ProjectsViewModel : ViewModelBase
    {
        private readonly IProjectRepository _projectRepository;

        public ObservableCollection<Project> Projects { get; } = [];

        public ProjectsViewModel(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
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
    }
}