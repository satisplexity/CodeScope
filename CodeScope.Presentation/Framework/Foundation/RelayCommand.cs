using System.Windows.Input;

namespace CodeScope.Presentation.Framework.Foundation
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;

        private readonly Predicate<object?>? _canExecute;

        /// <summary>
        /// Occurs when the command execution state changes.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Initializes a command with a parameterless 
        /// execute action and optional can-execute condition.
        /// </summary>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            if(execute is null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            // Wrap a parameterless action into the common object? parameter format.
            _execute = _ => execute();

            // Wrap a parameterless condition into the common object? parameter format,
            // or set it to null if no condition is provided.
            _canExecute = canExecute is null
                ? null
                : _ => canExecute.Invoke();
        }

        /// <summary>
        /// Initializes a command with parameterized execute and can-execute delegates.
        /// </summary>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Checks whether the command can execute.
        /// </summary>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Executes the provided action.
        /// </summary>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Notifies the UI that it should check CanExecute again.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}