using CodeScope.Presentation.Framework.Foundation;
using Microsoft.Win32;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AnalyzerSettingsStep
{
    public sealed class AnalyzerSettingsStepViewModel : ViewModelBase
    {
        public RelayCommand GoToAutomationStepCommand { get; }

        public RelayCommand GoToGeneralInfoStepCommand { get; }

        public RelayCommand AddExtensionCommand { get; }

        public RelayCommand RemoveExtensionCommand { get; }

        public RelayCommand AddIngnoredDirectoryCommand { get; }

        public RelayCommand RemoveIgnoredDirectoryCommand { get; }

        public RelayCommand AddIgnoredFileCommand { get; }
        public RelayCommand RemoveIgnoredFileCommand { get; }

        public RelayCommand SelectIgnoredDirectoryCommand { get; }
        public RelayCommand SelectIgnoredFileCommand { get; }

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

        public CreateProjectDraft Draft { get; }

        public AnalyzerSettingsStepViewModel(CreateProjectDraft draft, Action goToNextStepAction, Action goToPreviosStepAction)
        {
            Draft = draft;

            GoToAutomationStepCommand = new(goToNextStepAction);
            GoToGeneralInfoStepCommand = new(goToPreviosStepAction);

            AddExtensionCommand = new(AddExtension);
            RemoveExtensionCommand = new(RemoveExtension);

            AddIngnoredDirectoryCommand = new(AddIngnoredDirectory);
            RemoveIgnoredDirectoryCommand = new(RemoveIgnoredDirectory);

            AddIgnoredFileCommand = new(AddIgnoredFile);
            RemoveIgnoredFileCommand = new(RemoveIngoredFile);

            SelectIgnoredDirectoryCommand = new(SelectIgnoredDirectory);
            SelectIgnoredFileCommand = new(SelectIgnoredFile);
        }

        private void AddExtension()
        {
            string extension = NewExtension.Trim();

            if (string.IsNullOrWhiteSpace(extension))
                return;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if (!Draft.IncludedExtensions.Contains(extension))
                Draft.IncludedExtensions.Add(extension);

            NewExtension = string.Empty;
        }

        private void RemoveExtension(object? parameter)
        {
            if (parameter is string extension)
                Draft.IncludedExtensions.Remove(extension);
        }

        private void AddIngnoredDirectory()
        {
            string directory = NewIngnoredDirectory.Trim();

            if (string.IsNullOrWhiteSpace(directory))
                return;

            if (!Draft.IgnoredDirectories.Contains(directory))
                Draft.IgnoredDirectories.Add(directory);

            NewIngnoredDirectory = string.Empty;
        }

        private void RemoveIgnoredDirectory(object? parameter)
        {
            if (parameter is string directory)
                Draft.IgnoredDirectories.Remove(directory);
        }

        private void AddIgnoredFile()
        {
            string file = NewIgnoredFile.Trim();

            if (string.IsNullOrWhiteSpace(file))
                return;

            if (!Draft.IgnoredFiles.Contains(file))
                Draft.IgnoredFiles.Add(file);
        }

        private void RemoveIngoredFile(object? parameter)
        {
            if (parameter is string file)
                Draft.IgnoredFiles.Remove(file);
        }

        private void SelectIgnoredDirectory()
        {
            OpenFolderDialog dialog = new OpenFolderDialog();
            dialog.Title = "Select ignored directory";

            if (dialog.ShowDialog() == true)
            {
                NewIngnoredDirectory = dialog.FolderName;
            }
        }

        private void SelectIgnoredFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select ignored file";

            if (dialog.ShowDialog() == true)
            {
                NewIgnoredFile = dialog.FileName;
            }
        }
    }
}
