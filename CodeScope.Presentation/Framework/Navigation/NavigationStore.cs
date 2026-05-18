using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Framework.Navigation
{
    public class NavigationStore : ObservableObject
    {
        private ViewModelBase? _currentViewModel;

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
    }
}