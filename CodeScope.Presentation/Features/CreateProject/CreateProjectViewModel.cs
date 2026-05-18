using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.CreateProject
{
    public sealed class CreateProjectViewModel : ViewModelBase
    {
        public RelayCommand GoBackCommand { get; }
        
        public CreateProjectViewModel(IRootNavigationService navigation)
        {
            GoBackCommand = new(navigation.GoBack);
        }
    }
}