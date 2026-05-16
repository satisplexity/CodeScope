namespace CodeScope.Presentation.ViewModels.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        public Action<ViewModelBase>? SwitchViewAction { get; set; }

        protected void SwitchView(ViewModelBase viewModel) => SwitchViewAction?.Invoke(viewModel);

        public Action? GoToLastViewAction { get; set; }
        protected void GoToLastView() => GoToLastViewAction?.Invoke();
    }
}