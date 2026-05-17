namespace CodeScope.Presentation.Framework.Foundation
{
    public sealed class RelayCommand : CommandBase
    {
        private readonly Action<object?> _execute;

        private readonly Predicate<object?>? _canExecute;

        /// <summary>
        /// Initializes a command with a parameterless 
        /// execute action and optional can-execute condition.
        /// </summary>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            if(execute is null)
                throw new ArgumentNullException(nameof(execute));

            _execute = _ => execute();

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
        public override bool CanExecute(object? parameter) =>
            _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Executes the provided action.
        /// </summary>
        public override void Execute(object? parameter) =>
            _execute(parameter);
    }
}