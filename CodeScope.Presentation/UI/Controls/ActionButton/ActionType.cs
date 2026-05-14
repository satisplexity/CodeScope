namespace CodeScope.Presentation.UI.Controls.ActionButton
{
    /// <summary>
    /// Represents the semantic intent of an action.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Neutral action used for standard interactions, navigation or secondary actions.
        /// </summary>
        Default,

        /// <summary>
        /// Primary action that represents the main action or workflow on the current screen.
        /// </summary>
        Primary,

        /// <summary>
        /// Positive action that related to confirmation, creation or saving data.
        /// </summary>
        Success,

        /// <summary>
        /// Destructive or potentially irreversible action such as deleting or closing without saving.
        /// </summary>
        Danger
    }
}