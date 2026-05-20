using CodeScope.Application.Projects.Models;
using CodeScope.Domain.Projects.Entities;

namespace CodeScope.Application.Projects.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectModel ToModel(Project project) =>
            new ProjectModel()
            {
                Id = project.Id,
                Name = project.Name,
                RootPath = project.RootPath,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                LastActivityAt = project.LastActivityAt,
                LastScanAt = project.LastScanAt,
                ScannerSettings = ToModel(project.ScannerSettings),
                ColorKey = project.ColorKey,
                IconKey = project.IconKey,
                IsArchived = project.IsArchived,
            };

        public static List<ProjectModel> ToModel(List<Project> projects)
        {
            List<ProjectModel> models = new List<ProjectModel>();

            foreach(Project project in projects)
                models.Add(ToModel(project));

            return models;
        }

        public static Project ToDomain(ProjectModel project) =>
            new Project()
            {
                Id = project.Id,
                Name = project.Name,
                RootPath = project.RootPath,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                LastActivityAt = project.LastActivityAt,
                LastScanAt = project.LastScanAt,
                ScannerSettings = ToDomain(project.ScannerSettings),
                ColorKey = project.ColorKey,
                IconKey = project.IconKey,
                IsArchived = project.IsArchived,
            };

        private static ProjectScannerSettingsModel ToModel(ProjectScannerSettings settings) =>
            new ProjectScannerSettingsModel()
            {
                Extensions = settings.Extensions,
                IgnoredFiles = settings.IgnoredFiles,
                IgnoredDirectories = settings.IgnoredDirectories,
            };

        private static ProjectScannerSettings ToDomain(ProjectScannerSettingsModel settings) =>
            new ProjectScannerSettings()
            {
                Extensions = settings.Extensions,
                IgnoredFiles = settings.IgnoredFiles,
                IgnoredDirectories = settings.IgnoredDirectories,
            };
    }
}