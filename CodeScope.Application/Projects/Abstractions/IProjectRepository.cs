using CodeScope.Domain.Projects.Entities;

namespace CodeScope.Application.Projects.Abstractions
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();

        Task<Project?> GetByIdAsync(Guid id);
        
        Task AddAsync(Project project);

        Task ArchiveAsync(Guid id);

        Task RestoreAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task SaveChangesAsync();
    }
}