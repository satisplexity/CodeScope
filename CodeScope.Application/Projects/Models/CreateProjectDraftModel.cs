namespace CodeScope.Application.Projects.Models
{
    public class CreateProjectDraftModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RootPath { get; set; } = string.Empty;

        public List<string> Extensions { get; set; } = [];
        public List<string> IgnoredDirectories { get; set; } = [];
        public List<string> IgnoredFiles { get; set; } = [];

        public string ColorKey { get; set; } = string.Empty;
        public string IconKey { get; set; } = string.Empty;
    }
}