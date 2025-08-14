
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Models.csproj
// Created           : 20/02/2025, @gisvlasta
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Database.Entities {

  /// <summary>
  /// Provides the contract for a hash code property.
  /// </summary>
  public interface IHashCode {

    /// <summary>
    /// Gets/Sets the hash code value.
    /// </summary>
    public int? HashCode {
      get;
      set;
    }

  }

}
