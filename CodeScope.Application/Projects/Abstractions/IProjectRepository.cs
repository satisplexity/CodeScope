using CodeScope.Domain.Projects;

namespace CodeScope.Application.Projects.Abstractions
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();

        Task<Project?> GetByIdAsync(Guid id);
        
        Task AddAsync(Project project);

        Task DeleteAsync(Guid id);

        Task SaveChangesAsync();
    }
}