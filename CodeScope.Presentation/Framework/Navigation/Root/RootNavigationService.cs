using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Framework.Navigation.Root
{
    public sealed class RootNavigationService
        : NavigationService, IRootNavigationService
    {
        public RootNavigationService(RootNavigationStore store, IServiceProvider serviceProvider)
            : base(store, serviceProvider)
        {

        }
    }
}