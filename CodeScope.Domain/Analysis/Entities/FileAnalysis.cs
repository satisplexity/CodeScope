namespace CodeScope.Domain.Analysis.Entities
{
    public class FileAnalysis
    {
        public Guid Id { get; set; }
        public Guid SnapshotId { get; set; }

        public string Hash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Extension { get; set;  } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;

        public int SizeBytes { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}