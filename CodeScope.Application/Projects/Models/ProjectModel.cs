using CodeScope.Application.Shared.Models;

namespace CodeScope.Application.Projects.Models
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string RootPath { get; set; } = string.Empty;
        public string? Description { get; set; }

        
        public DateTime CreatedAt { get; set; }
        public DateTime LastActivityAt { get; set; }
        public DateTime? LastScanAt { get; set; }

        public ProjectScannerSettingsModel ScannerSettings { get; set; } = new();

        public string IconKey { get; set; } = string.Empty;
        public string ColorKey { get; set; } = string.Empty;

        public StatisticsModel Statistics { get; set; } = new();
        public bool IsArchived { get; set; }
    }
}