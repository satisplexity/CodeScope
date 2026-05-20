using CodeScope.Domain.Projects;

namespace CodeScope.Application.Snapshots.Abstractions
{
    public interface ISnapshotRepository
    {
        Task<List<ProjectSnapshot>> GetByProjectIdAsync(Guid projectId);

        Task SaveAsync(ProjectSnapshot snapshot);
    }
}