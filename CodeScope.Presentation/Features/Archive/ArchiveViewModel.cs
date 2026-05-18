using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.Archive
{
    public sealed class ArchiveViewModel : ViewModelBase
    {
        public RelayCommand GoBackCommand { get; }

        public ArchiveViewModel(IRootNavigationService navigation)
        {
            GoBackCommand = new(navigation.GoBack);
        }
    }
}