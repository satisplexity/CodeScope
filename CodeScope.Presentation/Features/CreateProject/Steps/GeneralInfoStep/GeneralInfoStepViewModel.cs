using CodeScope.Presentation.Framework.Foundation;
using Microsoft.Win32;
using System.IO;

namespace CodeScope.Presentation.Features.CreateProject.Steps.GeneralInfoStep
{
    public sealed class GeneralInfoStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAnalyzerSettingStepCommand { get; }

        public RelayCommand SelectRootPathCommand { get; }

        public RelayCommand AddExtensionCommand { get; }

        public RelayCommand RemoveExtensionCommand { get; }

        public RelayCommand AddDirectoryIgnoringCommand { get; }

        public RelayCommand RemoveDirectoryIgnoringCommand { get; }

        public RelayCommand AddFileIgnoringCommand { get; }
        public RelayCommand RemoveFileIgnoringCommand { get; }

        public string ProjectName
        {
            get => Draft.ProjectName;
            set
            {
                Draft.ProjectName = value;
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
                    ProjectName = new DirectoryInfo(value).Name;
                }

                OnPropertyChanged();
            }
        }

        private string _newExtension = string.Empty;
        public string NewExtension
        {
            get => _newExtension;
            set => SetProperty(ref _newExtension, value);
        }

        private string _newIgnoredDirectory = string.Empty;

        public string NewIngnoredDirectory
        {
            get => _newIgnoredDirectory;
            set => SetProperty(ref _newIgnoredDirectory, value);
        }

        private string _newIgnoredFile = string.Empty;

        public string NewIgnoredFile
        {
            get => _newIgnoredFile;
            set => SetProperty(ref _newIgnoredFile, value);
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

        private void AddExtension()
        {
            string extension = NewExtension.Trim();

            if (string.IsNullOrWhiteSpace(extension))
                return;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if(!Draft.IncludedExtensions.Contains(extension))
                Draft.IncludedExtensions.Add(extension);

            NewExtension = string.Empty;
        }

        private void RemoveExtension(object? parameter)
        {
            if(parameter is string extension)
                Draft.IncludedExtensions.Remove(extension);
        }

        private void AddIngnoredDirectory()
        {
            string directory = NewIngnoredDirectory.Trim();

            if (string.IsNullOrWhiteSpace(directory))
                return;

            if(!Draft.IgnoredDirectories.Contains(directory))
                Draft.IgnoredDirectories.Add(directory);

            NewIngnoredDirectory = string.Empty;
        }

        private void RemoveIgnoredDirectory(object? parameter)
        {
            if(parameter is string directory)
                Draft.IgnoredDirectories.Remove(directory);
        }

        private void AddIgnoredFile()
        {
            string file = NewIgnoredFile.Trim();

            if (string.IsNullOrWhiteSpace(file))
                return;

            if(!Draft.IgnoredFiles.Contains(file))
                Draft.IgnoredFiles.Add(file);
        }

        private void RemoveIngoredFile(object? parameter)
        {
            if(parameter is string file)
                Draft.IgnoredFiles.Remove(file);
        }
    }
}