using CodeScope.Presentation.Commands;
using CodeScope.Presentation.ViewModels.Base;
using System.Diagnostics;

namespace CodeScope.Presentation.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        public RelayCommand CreateProjectCommand { get; }

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

        public CreateProjectViewModel()
        {
            CreateProjectCommand = new RelayCommand(CreateProject, CanCreateProject);
        }

        private bool CanCreateProject()
        {
            ///!!!!!!! MAKE VALIDATION
            return !string.IsNullOrWhiteSpace(ProjectName);
        }

        private void CreateProject()
        {
            Debug.WriteLine("CREATE PROJECT COMMAND");
            //// PROJECT CREATION LOGIC
        }
    }
}