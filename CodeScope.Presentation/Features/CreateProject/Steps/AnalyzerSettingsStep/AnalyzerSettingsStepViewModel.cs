using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Models;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace CodeScope.Presentation.Features.CreateProject.Steps.AnalyzerSettingsStep
{
    public sealed class AnalyzerSettingsStepViewModel : ViewModelBase
    {
        public RelayCommand GoToCustomizationStepCommand { get; }
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

        public ObservableCollection<string> Extensions { get; }
        public ObservableCollection<string> IgnoredFiles { get; }
        public ObservableCollection<string> IgnoredDirectories { get; }

        private readonly CreateProjectDraftModel _draft;

        public AnalyzerSettingsStepViewModel(CreateProjectDraftModel draft, Action goToNextStepAction, Action goToPreviosStepAction)
        {
            _draft = draft;

            GoToCustomizationStepCommand = new(goToNextStepAction);
            GoToGeneralInfoStepCommand = new(goToPreviosStepAction);

            AddExtensionCommand = new(AddExtension);
            RemoveExtensionCommand = new(RemoveExtension);

            AddIngnoredDirectoryCommand = new(AddIngnoredDirectory);
            RemoveIgnoredDirectoryCommand = new(RemoveIgnoredDirectory);

            AddIgnoredFileCommand = new(AddIgnoredFile);
            RemoveIgnoredFileCommand = new(RemoveIngoredFile);

            SelectIgnoredDirectoryCommand = new(SelectIgnoredDirectory);
            SelectIgnoredFileCommand = new(SelectIgnoredFile);

            Extensions = new ObservableCollection<string>(draft.Extensions);
            IgnoredFiles = new ObservableCollection<string>(draft.IgnoredFiles);
            IgnoredDirectories = new ObservableCollection<string>(draft.IgnoredDirectories);
        }

        private void AddExtension()
        {
            string extension = NewExtension.Trim();

            if (string.IsNullOrWhiteSpace(extension))
                return;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if (!Extensions.Contains(extension))
            {
                Extensions.Add(extension);
                _draft.Extensions = Extensions.ToList();
            }
                
            NewExtension = string.Empty;
        }

        private void RemoveExtension(object? parameter)
        {
            if (parameter is string extension)
            {
                Extensions.Remove(extension);
                _draft.Extensions = Extensions.ToList();
            }
        }

        private void AddIngnoredDirectory()
        {
            string directory = NewIngnoredDirectory.Trim();

            if (string.IsNullOrWhiteSpace(directory))
                return;

            if (!IgnoredDirectories.Contains(directory))
            {
                IgnoredDirectories.Add(directory);
                _draft.IgnoredDirectories = IgnoredDirectories.ToList();
            }
                
            NewIngnoredDirectory = string.Empty;
        }

        private void RemoveIgnoredDirectory(object? parameter)
        {
            if (parameter is string directory)
            {
                IgnoredDirectories.Remove(directory);
                _draft.IgnoredDirectories = IgnoredDirectories.ToList();
            }  
        }

        private void AddIgnoredFile()
        {
            string file = NewIgnoredFile.Trim();

            if (string.IsNullOrWhiteSpace(file))
                return;

            if (!_draft.IgnoredFiles.Contains(file))
            {
                IgnoredFiles.Add(file);
                _draft.IgnoredFiles = IgnoredFiles.ToList();
            }  

            NewIgnoredFile = string.Empty;
        }

        private void RemoveIngoredFile(object? parameter)
        {
            if (parameter is string file)
            {
                IgnoredFiles.Remove(file);
                _draft.IgnoredFiles = IgnoredFiles.ToList();
            }
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