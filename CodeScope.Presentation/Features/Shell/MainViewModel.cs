using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Features.Shell
{
    public sealed class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public MainViewModel()
        {

        }
    }
}