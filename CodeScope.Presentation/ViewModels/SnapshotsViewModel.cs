using CodeScope.Application.Projects.Abstractions;
using CodeScope.Domain.Projects;
using CodeScope.Presentation.Commands;
using CodeScope.Presentation.ViewModels.Base;
using System.Collections.ObjectModel;

namespace CodeScope.Presentation.ViewModels
{
    public class SnapshotsViewModel : ViewModelBase
    {
        private readonly ISnapshotRepository _snapshotRepository;

        public RelayCommand CreateSnapshotCommand { get; }

        public ObservableCollection<ProjectSnapshot> Snapshots { get; } = new();

        public Project? SelectedProject;

        public SnapshotsViewModel(ISnapshotRepository snapshotRepository, Project project)
        {
            _snapshotRepository = snapshotRepository;
            SelectedProject = project;

            CreateSnapshotCommand = new RelayCommand(CreateSnapshotAsync);

            _ = LoadSnapshotsAsync(SelectedProject.Id);
        }

        public async Task LoadSnapshotsAsync(Guid projectId)
        {
            Snapshots.Clear();

            var snapshots = await _snapshotRepository
                .GetByProjectIdAsync(projectId);

            foreach (var snapshot in snapshots)
            {
                Snapshots.Add(snapshot);
            }
        }

        private async void CreateSnapshotAsync()
        {
            if (SelectedProject is null)
                return;

            var snapshot = new ProjectSnapshot
            {
                Id = Guid.NewGuid(),

                ProjectId = SelectedProject.Id,

                Name = $"Snapshot {DateTime.Now:HH:mm:ss}",

                CreatedAt = DateTime.Now,

                TotalFiles = 100,
                TotalLines = 10000,
                CodeLines = 7000,
                CommentLines = 2000,
                EmptyLines = 1000
            };

            await _snapshotRepository.SaveAsync(snapshot);

            Snapshots.Insert(0, snapshot);
        }
    }
}