
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
  /// The type of an ISO 639-3 code.
  /// </summary>
  public enum CodeType {

    /// <summary>
    /// The code is an ancient language.
    /// </summary>
    Ancient,

    /// <summary>
    /// The code is a constructed language.
    /// </summary>
    Constructed,

    /// <summary>
    /// The code is a dead language.
    /// </summary>
    Extinct,

    /// <summary>
    /// The code is a historical language.
    /// </summary>
    Historical,

    /// <summary>
    /// The code is a living language.
    /// </summary>
    Living,

    /// <summary>
    /// The code is a special language.
    /// </summary>
    Special

  }

}
