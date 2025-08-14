
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Globalization.csproj
// Created           : 12/02/2022, @pigeonwatcher
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Globalization.Languages {

  /// <summary>
  /// The reason for the retirement of an ISO 639-3 code.
  /// </summary>
  public enum RetirementReason {

    /// <summary>
    /// The code was changed.
    /// </summary>
    Change,

    /// <summary>
    /// The code was a duplicate.
    /// </summary>
    Duplicate,

    /// <summary>
    /// The code is non-existent.
    /// </summary>
    NonExistent,

    /// <summary>
    /// The code was split.
    /// </summary>
    Split,

    /// <summary>
    /// The code was merged.
    /// </summary>
    Merge

  }

}
