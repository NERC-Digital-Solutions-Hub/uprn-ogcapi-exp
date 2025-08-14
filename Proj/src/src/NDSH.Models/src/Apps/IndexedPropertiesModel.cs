
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Apps {

  /// <summary>
  /// The IndexedPropertiesModel is used in cases where the properties
  /// of the model should be accessed using a string indexer.
  /// </summary>
  public abstract class IndexedPropertiesModel : Model {

    // The cache used to store the PropertyInfo of a property. The Tuple (Type, string) ensures that
    // the keys stored in the cache are unique (no collisions will happen in  case of properties
    // with the same name exist in more than one types.
    private static readonly ConcurrentDictionary<(Type, string), PropertyInfo?> _propertyCache = new();

    /// <summary>
    /// Indexer to access property values by property name.
    /// </summary>
    /// <param name="propertyName">The name of the property to access.</param>
    /// <returns>
    /// The <see cref="string"/> representation of the property value, or null if the property is not found.
    /// </returns>
    /// <remarks>
    /// Expects that the property type is convertible from/to string.
    /// </remarks>
    public string? this[string propertyName] {
      get {
        PropertyInfo? propertyInfo = GetPropertyInfo(propertyName) ??
          throw new ArgumentException("The property was not found", nameof(propertyName)); // RESOURCE

        if (!propertyInfo.CanRead) {
          throw new InvalidOperationException($"The property '{propertyName}' is write-only."); // RESOURCE
        }

        object? value = propertyInfo.GetValue(this);
        return value?.ToString();
      }
      set {
        PropertyInfo? propertyInfo = GetPropertyInfo(propertyName) ??
          throw new ArgumentException("The property was not found", nameof(propertyName)); // RESOURCE

        if (!propertyInfo.CanWrite) {
          throw new InvalidOperationException($"Property '{propertyName}' is read-only."); // RESOURCE
        }

        try {
          object? convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
          propertyInfo.SetValue(this, convertedValue);
        }
        catch (Exception ex) when (
            ex is FormatException ||
            ex is InvalidCastException ||
            ex is OverflowException
        ) {
          throw new InvalidOperationException($"Unable to convert '{value}' to {propertyInfo.PropertyType}.", ex); // RESOURCE
        }
      }
    }

    /// <summary>
    /// Gets the <see cref="PropertyInfo"/> for the specified property,
    /// leveraging a cache to avoid repeated reflection.
    /// </summary>
    /// <param name="propertyName">
    /// The property name whose <see cref="PropertyInfo"/> will be retrieved.
    /// </param>
    /// <returns>
    /// A <see cref="PropertyInfo"/> object, or <see langword="null"/> if none is found.
    /// </returns>
    private PropertyInfo? GetPropertyInfo(string propertyName) {

      (Type, string) cacheKey = (this.GetType(), propertyName);

      return _propertyCache.GetOrAdd(cacheKey, static key => {
        // This does not skip indexers.
        return key.Item1.GetProperty(key.Item2, BindingFlags.Public | BindingFlags.Instance);
      });

    }

  }

}
