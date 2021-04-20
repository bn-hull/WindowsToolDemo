using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Windows_Tool_Demo.Boilerplate
{
    /// <summary>
    /// Implements INotifyPropertyChanged.
    /// Classes that inherit this object can call OnPropertyChanged at any time to
    ///     raises the PropertyChanged event with the name of the property that has changed
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the OnPropertyChanged property for this event
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!CheckPropertyName(propertyName))
            {
                throw new ArgumentException("Property name: " + propertyName + " does not exist");
            }

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName)
                );
            }
        }

        /// <summary>
        /// Checks if property is a member of the class that inherits from this
        /// returns true if it is
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns> returns true when property does exist, returns false when it doesn't</returns>
        private bool CheckPropertyName(string propertyName)
        {
            return !(TypeDescriptor.GetProperties(this)[propertyName] == null);
        }
    }
}