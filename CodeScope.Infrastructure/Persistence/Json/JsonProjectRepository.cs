using System.Text.Json;
using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;

namespace CodeScope.Infrastructure.Persistence.Json
{
    public class JsonProjectRepository : IProjectRepository
    {
        private readonly string _filePath;

        private List<Project> _projects = [];

        public JsonProjectRepository()
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CodeScope");

            Directory.CreateDirectory(appDataPath);

            _filePath = Path.Combine(appDataPath, "projects.json");
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            await LoadAsync();

            return _projects;
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            await LoadAsync();

            return _projects.FirstOrDefault(project => project.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await LoadAsync();

            _projects.Add(project);
        }

        public async Task DeleteAsync(Guid id)
        {
            await LoadAsync();

            Project? project = _projects.FirstOrDefault(p => p.Id == id);

            if (project is not null)
            {
                _projects.Remove(project);
            }
        }

        public async Task SaveChangesAsync()
        {
            string json = JsonSerializer.Serialize(_projects, new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(_filePath, json);
        }

        private async Task LoadAsync()
        {
            if (_projects.Count > 0)
            {
                return;
            }

            if (!File.Exists(_filePath))
            {
                _projects = [];

                return;
            }

            var json = await File.ReadAllTextAsync(_filePath);

            _projects = JsonSerializer.Deserialize<List<Project>>(json) ?? [];
        }
    }
}