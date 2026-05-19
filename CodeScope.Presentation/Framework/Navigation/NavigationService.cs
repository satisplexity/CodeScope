using CodeScope.Presentation.Framework.Foundation;
using CodeScope.Presentation.Framework.Navigation.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CodeScope.Presentation.Framework.Navigation
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly NavigationStore _store;
        private readonly IServiceProvider _services;
        private readonly Stack<ViewModelBase> _history = new();

        public ViewModelBase? CurrentViewModel => _store.CurrentViewModel;

        public bool CanGoBack => _history.Count > 0;

        public NavigationService(NavigationStore store, IServiceProvider services)
        {
            _store = store;
            _services = services;

            _store.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(NavigationStore.CurrentViewModel))
                    OnPropertyChanged(nameof(CurrentViewModel));
            };
        }

        public void NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase =>
            _ = NavigateTo(typeof(TViewModel), null);

        public void NavigateTo<TViewModel, TParameter>(TParameter parameter)
            where TViewModel : ViewModelBase =>
            _ =NavigateTo(typeof(TViewModel), parameter);

        private async Task NavigateTo(Type viewModelType, object? parameter)
        {
            if(_store.CurrentViewModel is not null)
                _history.Push(_store.CurrentViewModel);

            _store.CurrentViewModel = parameter is null
                ? (ViewModelBase)_services.GetRequiredService(viewModelType)
                : (ViewModelBase)ActivatorUtilities.CreateInstance(_services, viewModelType, parameter);

            if (_store.CurrentViewModel is IAsyncInitializable asyncInitializable)
                await asyncInitializable.InitializeAsync();

            OnPropertyChanged(nameof(CanGoBack));
        }

        public void GoBack()
        {
            if(!CanGoBack)
                return;

            _store.CurrentViewModel = _history.Pop();

            OnPropertyChanged(nameof(CanGoBack));
        }
    }
}