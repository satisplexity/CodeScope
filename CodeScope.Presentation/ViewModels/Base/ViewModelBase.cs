namespace CodeScope.Presentation.ViewModels.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        public Action<ViewModelBase>? ShowOverlayAction { get; set; }

        protected void ShowOverlay(ViewModelBase overlayContent) => ShowOverlayAction?.Invoke(overlayContent);

        public Action? HideOverlayAction { get; set; }

        protected void HideOverlay() => HideOverlayAction?.Invoke();
    }
}