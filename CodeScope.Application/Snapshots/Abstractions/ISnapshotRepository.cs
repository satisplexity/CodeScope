using CodeScope.Domain.Snapshots.Entities;

namespace CodeScope.Application.Snapshots.Abstractions
{
    public interface ISnapshotRepository
    {
        Task<List<Snapshot>> GetByProjectIdAsync(Guid projectId);

        Task SaveAsync(Snapshot snapshot);
    }
}