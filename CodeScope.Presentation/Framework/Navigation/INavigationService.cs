using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Framework.Navigation
{
    public interface INavigationService
    {
        ViewModelBase CurrentViewModel { get; }

        void NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase;

        void NavigateTo<TViewModel, TParameter>(TParameter parameter)
            where TViewModel : ViewModelBase;

        bool CanGoBack { get; }

        void GoBack();
    }
}