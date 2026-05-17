using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CodeScope.Presentation.Framework.Foundation
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Raises when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;

            OnPropertyChanged(propertyName);
            
            return true;
        }
    }
}