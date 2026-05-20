using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Application.Projects.Abstractions;
using System.Collections.ObjectModel;
using CodeScope.Domain.Projects;

namespace CodeScope.Presentation.Features.Archive
{
    public sealed class ArchiveViewModel : ViewModelBase, IAsyncInitializable
    {
        public RelayCommand GoBackCommand { get; }

        public ObservableCollection<Project> Projects { get; } = [];

        private readonly IProjectRepository _repository;

        public ArchiveViewModel(IRootNavigationService navigation, IProjectRepository repository)
        {
            _repository = repository;

            GoBackCommand = new(navigation.GoBack);
        }

        public async Task InitializeAsync()
        {
            List<Project> projects = await _repository.GetAllProjectsAsync();

            Projects.Clear();

            foreach (Project project in projects)
                if (!project.IsArchived)
                    Projects.Add(project);
        }
    }
}