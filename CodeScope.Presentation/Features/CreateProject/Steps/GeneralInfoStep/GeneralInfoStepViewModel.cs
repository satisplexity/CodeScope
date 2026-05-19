using CodeScope.Presentation.Framework.Foundation;
using Microsoft.Win32;
using System.IO;

namespace CodeScope.Presentation.Features.CreateProject.Steps.GeneralInfoStep
{
    public sealed class GeneralInfoStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAnalyzerSettingStepCommand { get; }

        public RelayCommand SelectRootPathCommand { get; }


        public string ProjectName
        {
            get => Draft.Name;
            set
            {
                Draft.Name = value;
                _projectNameHasBeenChanged = true;
                OnPropertyChanged();
            }
        }

        public string? ProjectDescription
        {
            get => Draft.Description;
            set
            {
                Draft.Description = value;
                OnPropertyChanged();
            }
        }

        public string RootPath
        {
            get => Draft.RootPath;
            set
            {
                Draft.RootPath = value;

                if (!_projectNameHasBeenChanged)
                {
                    Draft.Name = new DirectoryInfo(value).Name;
                    OnPropertyChanged(nameof(ProjectName));
                }

                OnPropertyChanged();
            }
        }


        private bool _projectNameHasBeenChanged = false;

        public CreateProjectDraft Draft { get; }


        public GeneralInfoStepViewModel(CreateProjectDraft draft, Action goToNextStepAction)
        {
            Draft = draft;

            GoToAnalyzerSettingStepCommand = new(goToNextStepAction);
            SelectRootPathCommand = new(SelectRootPath);
        }

        private void SelectRootPath()
        {
            OpenFolderDialog dialog = new OpenFolderDialog();

            dialog.Title = "Select project root folder";

            if(dialog.ShowDialog() == true)
            {
                RootPath = dialog.FolderName;
            }
        }
    }
}