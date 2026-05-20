using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Models;
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
            get => _draft.Name;
            set
            {
                _draft.Name = value;
                _projectNameHasBeenChanged = true;
                OnPropertyChanged();
            }
        }

        public string ProjectDescription
        {
            get => _draft.Description;
            set
            {
                _draft.Description = value;
                OnPropertyChanged();
            }
        }

        public string RootPath
        {
            get => _draft.RootPath;
            set
            {
                _draft.RootPath = value;

                if (!_projectNameHasBeenChanged)
                {
                    _draft.Name = new DirectoryInfo(value).Name;
                    OnPropertyChanged(nameof(ProjectName));
                }

                OnPropertyChanged();
            }
        }

        private bool _projectNameHasBeenChanged = false;

        private readonly CreateProjectDraftModel _draft;

        public GeneralInfoStepViewModel(CreateProjectDraftModel draft, Action goToNextStepAction)
        {
            _draft = draft;

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