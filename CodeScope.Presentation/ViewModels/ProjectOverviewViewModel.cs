using CodeScope.Domain.Projects;
using CodeScope.Infrastructure.Persistence.Json;
using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.ViewModels
{
    public class ProjectOverviewViewModel : ViewModelBase
    {
        public Project CurrentProject { get; }

        public string ProjectName
        {
            get => CurrentProject.Name;
        }

        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ProjectOverviewViewModel(Project project)
        {
            CurrentProject = project;

            SnapshotsViewModel snapshotsViewModel = new SnapshotsViewModel(new JsonSnapshotRepository(), project);

            //CurrentView = snapshotsViewModel;
        }
    }
}