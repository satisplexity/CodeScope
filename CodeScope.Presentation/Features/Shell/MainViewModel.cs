using CodeScope.Presentation.Features.ProjectsHub;
using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation;

namespace CodeScope.Presentation.Features.Shell
{
    public sealed class MainViewModel : ViewModelBase
    {
        public INavigationService RootNavigation { get; }

        public MainViewModel(INavigationService rootNavigation)
        {
            RootNavigation = rootNavigation;

            RootNavigation.NavigateTo<ProjectsHubViewModel>();
        }
    }
}