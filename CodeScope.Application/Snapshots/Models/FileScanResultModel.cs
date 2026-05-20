using CodeScope.Application.Shared.Models;

namespace CodeScope.Application.Snapshots.Models
{
    public class FileScanResultModel
    {
        public Guid Id { get; set; }
        public Guid SnapshotId { get; set; }
        
        public string Hash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;
        
        public int SizeBytes { get; set; }
        public StatisticsModel Statistics { get; set; } = new();

        public DateTime LastModifiedAt { get; set; }
    }
}