using CodeScope.Application.Shared.Models;

namespace CodeScope.Application.Snapshots.Models
{
    public class SnapshotModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ScannerVersion { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public TimeSpan ScanDuration { get; set; }

        public StatisticsModel Statistics { get; set; } = new();
    }
}