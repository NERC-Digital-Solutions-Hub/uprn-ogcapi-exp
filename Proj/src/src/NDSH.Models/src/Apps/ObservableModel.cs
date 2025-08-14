
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Models.csproj
// Created           : 13/02/2025, @gisvlasta
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Apps {

  /// <summary>
  /// Provides notifications to observers when model properties change.
  /// </summary>
  public abstract class ObservableModel : Model, IObservableModel {

    /// <summary>
    /// Sets the value of a property and notifies subscribers if the value changes.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the property to set.</typeparam>
    /// <param name="field">
    /// A reference to the backing field used to hold the value of the property.
    /// </param>
    /// <param name="value">The new value of the property.</param>
    /// <param name="propertyName">
    /// The name of the property. It is not necessary to provide the name of the property since the
    /// <see cref="CallerMemberNameAttribute"/> has been applied on the argument. The attribute is used
    /// to automatically discover the name of the property that is changed.
    /// </param>
    /// <returns>
    /// A <see cref="bool"/> indicating that the value of the property has been changed.
    /// </returns>
    /// <remarks>
    /// This method provides a standard approach for setting the value of a property while ensuring
    /// that the <see cref="PropertyChanged"/> event is raised if the value changes. It leverages the
    /// <see cref="CallerMemberNameAttribute"/> to automatically determine the property name, reducing
    /// the need for hardcoded strings. The method assumes that a private field backs the property
    /// and prevents unnecessary notifications when the value remains unchanged.
    /// </remarks>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {
      if (EqualityComparer<T>.Default.Equals(field, value)) {
        return false;
      }

      field = value;
      OnPropertyChanged(propertyName);

      return true;
    }

    #region IObservableModel Interface

    /// <summary>
    /// The event raised when a property has been changed.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises the <see cref="PropertyChanged" /> event.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed (optional).</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    #endregion

  }

}
