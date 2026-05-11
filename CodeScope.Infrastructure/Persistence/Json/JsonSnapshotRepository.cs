using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;
using System.Text.Json;

namespace CodeScope.Infrastructure.Persistence.Json
{
    public class JsonSnapshotRepository : ISnapshotRepository
    {
        private readonly string _snapshotsDirectory;

        public JsonSnapshotRepository()
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CodeScope");

            Directory.CreateDirectory(appDataPath);

            _snapshotsDirectory = Path.Combine(appDataPath, "snapshots");

            Directory.CreateDirectory(_snapshotsDirectory);
        }

        public async Task<List<ProjectSnapshot>> GetByProjectIdAsync(Guid projectId)
        {
            string path = GetProjectSnapshotsPath(projectId);

            if (!File.Exists(path))
                return new List<ProjectSnapshot>();

            string json = await File.ReadAllTextAsync(path);

            return JsonSerializer.Deserialize<List<ProjectSnapshot>>(json) ?? new List<ProjectSnapshot>();
        }

        public async Task SaveAsync(ProjectSnapshot snapshot)
        {
            List<ProjectSnapshot> snapshots = await GetByProjectIdAsync(snapshot.ProjectId);

            snapshots.Add(snapshot);

            string json = JsonSerializer.Serialize(snapshots, new JsonSerializerOptions { WriteIndented = true });

            var path = GetProjectSnapshotsPath(snapshot.ProjectId);

            await File.WriteAllTextAsync(path, json);
        }

        private string GetProjectSnapshotsPath(Guid projectId) => Path.Combine(_snapshotsDirectory, $"{projectId}.json");
    }
}