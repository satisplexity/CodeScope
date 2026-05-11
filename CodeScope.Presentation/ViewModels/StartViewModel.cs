using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;
using CodeScope.Presentation.Commands;
using CodeScope.Presentation.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CodeScope.Presentation.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private readonly IProjectRepository _projectRepository;

        public ObservableCollection<Project> Projects { get; } = [];

        public Action<Project>? OpenProjectAction;

        public RelayCommand CreateProjectCommand { get; }
        public RelayCommand DeleteProjectCommand { get; }

        public RelayCommand OpenProjectCommand { get; }

        private Project? _selectedProject;

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (SetProperty(ref _selectedProject, value))
                {
                    DeleteProjectCommand.RaiseCanExecuteChanged();
                    OpenProjectCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public StartViewModel(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            CreateProjectCommand = new RelayCommand(CreateProject);
            DeleteProjectCommand = new RelayCommand(DeleteProject, CheckProjectSeletct);
            OpenProjectCommand = new RelayCommand(OpenProject, CheckProjectSeletct);
        }

        public async Task LoadAsync()
        {
            List<Project> projects = await _projectRepository.GetAllProjectsAsync();

            Projects.Clear();

            foreach (Project project in projects)
            {
                Projects.Add(project);
            }

            Debug.WriteLine("Projects loaded");
        }

        private async void CreateProject()
        {
            CreateProjectViewModel createProjectViewModel = new CreateProjectViewModel(_projectRepository)
            {
                HideOverlayAction = this.HideOverlayAction,
                ProjectCreatedAction = OnProjectCreated,
                GoToLastViewAction = this.GoToLastViewAction
            };

            SwitchView(createProjectViewModel);
        }

        private bool CheckProjectSeletct() => SelectedProject is not null;

        private async void DeleteProject()
        {
            if (SelectedProject is null)
            {
                return;
            }

            await _projectRepository.DeleteAsync(SelectedProject.Id);
            await _projectRepository.SaveChangesAsync();

            Projects.Remove(SelectedProject);
        }

        private void OnProjectCreated(Project project)
        {
            Projects.Add(project);

            OpenProjectAction?.Invoke(project);
        }

        private void OpenProject()
        {
            if (SelectedProject is null)
            {
                return;
            }

            OpenProjectAction?.Invoke(SelectedProject);
        }
    }
}