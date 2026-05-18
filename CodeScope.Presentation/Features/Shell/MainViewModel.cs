using CodeScope.Presentation.Framework.Navigation.Abstractions;
using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.Shell
{
    public sealed class MainViewModel : ViewModelBase
    {
        public IRootNavigationService Navigation { get; }

        public MainViewModel(IRootNavigationService navigation)
        {
            Navigation = navigation;

            Navigation.NavigateTo<ProjectsHubViewModel>();
        }
    }
}