
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Apps {

  /// <summary>
  /// The interface used to define a model.
  /// </summary>
  public interface IModel {

    /// <summary>
    /// Gets a dictionary of property keys and their values as objects.
    /// </summary>
    /// <returns>
    /// A <see cref="ReadOnlyDictionary{String, String}"/> with keys
    /// having the property names and their values as objects.
    /// </returns>
    public ReadOnlyDictionary<string, object?> GetPropertyKeyValues();

    /// <summary>
    /// Gets a dictionary of property keys and their values represented as strings.
    /// </summary>
    /// <returns>
    /// A <see cref="ReadOnlyDictionary{String, String}"/> with keys having the property names and
    /// their values represented as <see cref="string">strings</see>.
    /// </returns>
    public ReadOnlyDictionary<string, string?> GetPropertyKeyValuesAsStrings();

  }

}
