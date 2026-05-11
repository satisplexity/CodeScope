using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;
using CodeScope.Presentation.Commands;
using CodeScope.Presentation.ViewModels.Base;
using System.Diagnostics;

namespace CodeScope.Presentation.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        private readonly IProjectRepository _projectRepository;

        public Action<Project>? ProjectCreatedAction { get; set; }

        public RelayCommand CreateProjectCommand { get; }
        public RelayCommand HideCreateProjectCommand { get; }

        private string _projectName = string.Empty;

        public string ProjectName
        {
            get => _projectName;
            set
            {
                if(SetProperty(ref _projectName, value))
                {
                    CreateProjectCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _projectDescription = string.Empty;

        public string ProjectDescription
        {
            get => _projectDescription;
            set => SetProperty(ref _projectDescription, value);
        }

        public CreateProjectViewModel(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            
            CreateProjectCommand = new RelayCommand(CreateProject, CanCreateProject);
            HideCreateProjectCommand = new RelayCommand(GoToLastView);
        }

        private bool CanCreateProject()
        {
            ///!!!!!!! MAKE VALIDATION
            return !string.IsNullOrWhiteSpace(ProjectName);
        }

        private async void CreateProject()
        {
            Debug.WriteLine("CREATE PROJECT COMMAND");
            Project project = new()
            {
                Id = Guid.NewGuid(),
                Name = ProjectName,
                Description = ProjectDescription,
                RootPath = @"P:\CodeScope",
                CreatedAt = DateTime.Now
            };

            await _projectRepository.AddAsync(project);

            await _projectRepository.SaveChangesAsync();

            ProjectCreatedAction?.Invoke(project);
        }
    }
}