namespace CodeScope.Application.Projects.Models
{
    public class ProjectScannerSettingsModel
    {
        public List<string> Extensions { get; set; } = [];
        public List<string> IgnoredFiles { get; set; } = [];
        public List<string> IgnoredDirectories { get; set; } = [];
    }
}