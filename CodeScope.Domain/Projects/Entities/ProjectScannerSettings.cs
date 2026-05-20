namespace CodeScope.Domain.Projects.Entities
{
    public class ProjectScannerSettings
    {
        public List<string> Extensions { get; set; } = [];
        public List<string> IgnoredFiles { get; set; } = [];
        public List<string> IgnoredDirectories { get; set; } = [];
    }
}