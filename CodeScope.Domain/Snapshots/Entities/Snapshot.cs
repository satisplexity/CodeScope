namespace CodeScope.Domain.Snapshots.Entities
{
    public class Snapshot
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string ScannerVersion { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public TimeSpan ScanDuration { get; set; }
    }
}