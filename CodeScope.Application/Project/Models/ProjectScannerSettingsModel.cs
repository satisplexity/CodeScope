namespace CodeScope.Application.Project.Models
{
    public class ProjectScannerSettingsModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        public List<string> Extensions { get; set; } = [];

        public List<string> IgnoredFiles { get; set; } = [];

        public List<string> IgnoredDirectories { get; set; } = [];
    }
}