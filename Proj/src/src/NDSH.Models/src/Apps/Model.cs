
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Apps {

  /// <summary>
  /// Represents the abstract base class for model inheritance scenarios.
  /// </summary>
  public abstract class Model : IModel {

    #region Public Methods

    // Used to cache the PropertyInfo array of each type.
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyCache = new();

    /// <summary>
    /// Gets a dictionary of property keys and their values represented as objects.
    /// </summary>
    /// <returns>
    /// A <see cref="ReadOnlyDictionary{String, Object}"/> with keys
    /// having the property names and their values as objects.
    /// Write-only properties and indexers are not returned.
    /// If any property's getter throws an exception, that property's value is stored as <see langword="null"/>.
    /// </returns>
    public ReadOnlyDictionary<string, object?> GetPropertyKeyValues() {

      // Retrieve or cache the readable, non-indexer properties for this type.
      PropertyInfo[]? properties = _propertyCache.GetOrAdd(
        this.GetType(),
        t => t.GetProperties().Where(p => p.CanRead && p.GetIndexParameters().Length == 0).ToArray()
      );

      Dictionary<string, object?> dictionary = new(properties.Length);

      foreach (PropertyInfo property in properties) {
        object? value;
        try {
          value = property.GetValue(this);
        }
        catch {
          // If the getter throws an exception, store null for that property.
          value = null;
        }

        dictionary[property.Name] = value;
      }

      return new ReadOnlyDictionary<string, object?>(dictionary);

    }

    /// <summary>
    /// Gets a dictionary of property keys and their values represented as strings.
    /// </summary>
    /// <returns>
    /// A <see cref="ReadOnlyDictionary{String, String}"/> with keys having the property names
    /// and values with the <see cref="string"/> representation of the property values.
    /// Write-only properties and indexers are not returned.
    /// Values that can not be converted will be converted to <see langword="null"/>.
    /// </returns>
    public ReadOnlyDictionary<string, string?> GetPropertyKeyValuesAsStrings() {

      // Retrieve or cache the readable, non-indexer properties for this type.
      PropertyInfo[]? properties = _propertyCache.GetOrAdd(
        this.GetType(),
        t => t.GetProperties().Where(p => p.CanRead && p.GetIndexParameters().Length == 0).ToArray()
      );

      Dictionary<string, string?> dictionary = new(properties.Length);

      foreach (PropertyInfo property in properties) {
        object? value;
        try {
          value = property.GetValue(this);
        }
        catch {
          // If the getter throws an exception, store null for that property.
          value = null;
        }
        dictionary[property.Name] = value?.ToString();
      }

      return new ReadOnlyDictionary<string, string?>(dictionary);

    }

    #endregion

  }

}
