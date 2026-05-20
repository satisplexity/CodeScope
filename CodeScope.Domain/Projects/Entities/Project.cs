namespace CodeScope.Domain.Projects.Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string RootPath { get; set; } = string.Empty;
        public string? Description { get; set; }


        public string IconKey { get; set; } = string.Empty;
        public string ColorKey { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime LastActivityAt { get; set;  }
        public DateTime? LastScanAt { get; set; }

        public bool IsArchived { get; set; }
        public ProjectScannerSettings ScannerSettings { get; set; } = new();
    }
}