namespace CodeScope.Domain.Projects
{
    public class ProjectSnapshot
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int TotalFiles { get; set; }

        public int TotalLines { get; set; }

        public int CodeLines { get; set; }

        public int CommentLines { get; set; }

        public int EmptyLines { get; set; }
    }
}