using CodeScope.Application.Projects.Abstractions;
using CodeScope.Application.Projects.Mappers;
using CodeScope.Application.Projects.Models;
using CodeScope.Domain.Projects.Entities;

namespace CodeScope.Application.Projects.Services
{
    public class CreateProjectService
    {
        private readonly IProjectRepository _repository;
        
        public CreateProjectService(IProjectRepository repository) =>
            _repository = repository;

        public async Task<ProjectModel> ExecuteAsync(CreateProjectDraftModel draft)
        {
            Project project = new()
            {
                Id = Guid.NewGuid(),
                Name = draft.Name,
                RootPath = draft.RootPath,
                Description = draft.Description,
                CreatedAt = DateTime.UtcNow,
                LastActivityAt = DateTime.UtcNow,
                ScannerSettings = new ProjectScannerSettings()
                {
                    Extensions = draft.Extensions,
                    IgnoredFiles = draft.IgnoredFiles,
                    IgnoredDirectories = draft.IgnoredDirectories,
                },
                ColorKey = draft.ColorKey,
                IconKey = draft.IconKey,
                IsArchived = false
            };

            await _repository.AddAsync(project);

            return ProjectMapper.ToModel(project);
        }
    }
}