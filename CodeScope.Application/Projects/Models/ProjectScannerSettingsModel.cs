namespace CodeScope.Application.Projects.Models
{
    public class ProjectScannerSettingsModel
    {
        public IReadOnlyList<string> Extensions { get; set; } = [];
        public IReadOnlyList<string> IgnoredFiles { get; set; } = [];
        public IReadOnlyList<string> IgnoredDirectories { get; set; } = [];
    }
}