using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Framework.Navigation.CreateProject
{
    public class CreateProjectNavigationService : NavigationService, ICreateProjectNavigationService
    {
        public CreateProjectNavigationService(CreateProjectNavigationStore store, IServiceProvider serviceProvider)
            : base(store, serviceProvider)
        {

        }
    }
}