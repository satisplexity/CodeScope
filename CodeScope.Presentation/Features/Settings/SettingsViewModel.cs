using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;

namespace CodeScope.Presentation.Features.Settings
{
    public sealed class SettingsViewModel : ViewModelBase
    {
        public AsyncRelayCommand GoBackCommand { get; }
        
        public SettingsViewModel(IRootNavigationService navigation)
        {
            GoBackCommand = new(navigation.GoBack);
        }
    }
}