using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace CodeScope.Presentation.UI.Controls.ActionButton
{
    /// <summary>
    /// Represents a reusable button control that supports
    /// semantic action types, customizable icons and text content.
    /// </summary>
    public class ActionButton : Button
    {
        /// <summary>
        /// Overrides the default style key to associate
        /// the control with its custom style defined in ActionButtonStyle.xaml.
        /// </summary>
        static ActionButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ActionButton),
                new FrameworkPropertyMetadata(typeof(ActionButton)));
        }

        #region Text DependencyProperty

        /// <summary>
        /// Gets or sets the text content of the button.
        /// </summary>
        public string? Text
        {
            get => (string?)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(ActionButton),
                new PropertyMetadata(null));

        #endregion

        #region IconData DependencyProperty

        /// <summary>
        /// Gets or sets the geometry that defines the icon's shape to be rendered.
        /// </summary>
        public Geometry? IconData
        {
            get => (Geometry?)GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }

        public static readonly DependencyProperty IconDataProperty =
            DependencyProperty.Register(
                nameof(IconData),
                typeof(Geometry),
                typeof(ActionButton),
                new PropertyMetadata(null));

        #endregion

        #region ActionType DependencyProperty

        /// <summary>
        /// Gets or sets the semantic aciton type
        /// that defines the button appearance.
        /// </summary>
        public ActionType ActionType
        {
            get => (ActionType)GetValue(ActionTypeProperty);
            set => SetValue(ActionTypeProperty, value);
        }

        public static readonly DependencyProperty ActionTypeProperty =
            DependencyProperty.Register(
                nameof(ActionType),
                typeof(ActionType),
                typeof(ActionButton),
                new PropertyMetadata(ActionType.Default));

        #endregion

        #region HasText Property

        public bool HasText =>
            !string.IsNullOrWhiteSpace(Text);

        #endregion

        #region HasIcon Property

        public bool HasIcon =>
            IconData is not null;

        #endregion
    }
}