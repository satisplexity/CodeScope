using CodeScope.Application.Snapshots.Abstractions;
using CodeScope.Domain.Snapshots.Entities;
using System.Text.Json;

namespace CodeScope.Infrastructure.Persistence.Json
{
    public class JsonSnapshotRepository : ISnapshotRepository
    {
        private readonly string _snapshotsDirectory;

        public JsonSnapshotRepository()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CodeScope");

            Directory.CreateDirectory(appDataPath);

            _snapshotsDirectory = Path.Combine(appDataPath, "snapshots");

            Directory.CreateDirectory(_snapshotsDirectory);
        }

        public async Task<List<Snapshot>> GetByProjectIdAsync(Guid projectId)
        {
            string path = GetSnapshotFilePath(projectId);

            if (!File.Exists(path))
                return new List<Snapshot>();

            string json = await File.ReadAllTextAsync(path);

            return JsonSerializer.Deserialize<List<Snapshot>>(json)
                   ?? new List<Snapshot>();
        }

        public async Task SaveAsync(Snapshot snapshot)
        {
            var snapshots = await GetByProjectIdAsync(snapshot.ProjectId);

            snapshots.Add(snapshot);

            string json = JsonSerializer.Serialize(
                snapshots,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            string path = GetSnapshotFilePath(snapshot.ProjectId);

            await File.WriteAllTextAsync(path, json);
        }

        private string GetSnapshotFilePath(Guid projectId)
        {
            return Path.Combine(
                _snapshotsDirectory,
                $"{projectId}.json");
        }
    }
}