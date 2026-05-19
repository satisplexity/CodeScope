using CodeScope.Presentation.Framework.Foundation;
using System.Collections.ObjectModel;

namespace CodeScope.Presentation.Features.CreateProject
{
    public class CreateProjectDraft : ObservableObject
    {
        public string RootPath { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;

        public string? Description { get; set;  } = string.Empty;


        public ObservableCollection<string> IncludedExtensions { get; } = [];
        public ObservableCollection<string> IgnoredDirectories { get; } = [];
        public ObservableCollection<string> IgnoredFiles { get; } = [];

        public bool CreateSnapshotOnAppOpen { get; set; } = false;
        public bool AutoSnapshotsEnabled { get; set; } = false;

        public string ColorKey { get; set; } = "#Default";
        public string IconKey { get; set; } = "Code";

    }
}