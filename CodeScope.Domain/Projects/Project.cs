namespace CodeScope.Domain.Projects
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }

        public string RootPath { get; set; } = string.Empty;

        public string IconKey {  get; set; } = "Code";

        public string ColotKey { get; set; } = "Default";

        public DateTime CreatedAt { get; set; }

        public List<string> IncludedExtensions { get; set; } = [];

        public List<string> IgnoredDirectories { get; set; } = [];

        public List<string> IgnoredFiles { get; set; } = [];

        public bool IsArchived { get; set; }
    }
}