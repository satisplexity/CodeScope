namespace CodeScope.Application.Project.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public ProjectScannerSettingsModel ScanerSettings { get; set; }

        public string IconKey { get; set; }

        public string ColorKey { get; set; }
    }
}