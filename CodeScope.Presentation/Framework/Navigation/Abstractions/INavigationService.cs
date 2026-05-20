using CodeScope.Presentation.Framework.Foundation;

namespace CodeScope.Presentation.Framework.Navigation.Abstractions
{
    public interface INavigationService
    {
        ViewModelBase? CurrentViewModel { get; }

        Task NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase;

        Task NavigateTo<TViewModel, TParameter>(TParameter parameter)
            where TViewModel : ViewModelBase;

        bool CanGoBack { get; }

        Task GoBack();
    }
}