using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;
using CodeScope.Presentation.Features.CreateProject;
using System.Diagnostics;

namespace CodeScope.Presentation.Framework.Services
{
    public sealed class CreateProjectService
    {
        private readonly IProjectRepository _repository;

        public CreateProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CreateProjectDraft draft)
        {
            Project project = new()
            {
                Id = Guid.NewGuid(),
                Name = draft.Name,
                Description = draft.Description,
                RootPath = draft.RootPath,
                CreatedAt = DateTime.UtcNow,
                ColotKey = draft.ColorKey,
                IconKey = draft.IconKey,
                IgnoredDirectories = draft.IgnoredDirectories.ToList(),
                IncludedExtensions = draft.IncludedExtensions.ToList(),
                IgnoredFiles = draft.IgnoredFiles.ToList(),
            };

            Debug.WriteLine($"PROJECT {draft.Name} IS CREATED");

            await _repository.AddAsync(project);
            await _repository.SaveChangesAsync();
        }
    }
}