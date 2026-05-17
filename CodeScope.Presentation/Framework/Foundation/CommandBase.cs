using System.Windows.Input;

namespace CodeScope.Presentation.Framework.Foundation
{
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// Raised when command availability may have changed.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);

        /// <summary>
        /// Notifies the UI to check CanExecute again.
        /// </summary>
        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}