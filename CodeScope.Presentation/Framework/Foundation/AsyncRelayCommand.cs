namespace CodeScope.Presentation.Framework.Foundation
{
    public sealed class AsyncRelayCommand : CommandBase
    {
        private readonly Func<object?, Task> _execute;

        private readonly Predicate<object?>? _canExecute;

        private bool _isExecuting;

        /// <summary>
        /// Initializes a command with a parameterless 
        /// execute action and optional can-execute condition.
        /// </summary>
        public AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
        {
            if (_execute is null)
                throw new ArgumentNullException(nameof(execute));

            _execute = _ => execute();

            _canExecute = canExecute is null
                ? null
                : _ => canExecute();
        }

        /// <summary>
        /// Initializes a command with parameterized execute and can-execute delegates.
        /// </summary>
        public AsyncRelayCommand(Func<object?, Task> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute and is not already running.
        /// </summary>
        public override bool CanExecute(object? parameter) =>
            !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);

        public override async void Execute(object? parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            try
            {
                _isExecuting = true;
                RaiseCanExecuteChanged();
                await _execute(parameter);
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }
    }
}