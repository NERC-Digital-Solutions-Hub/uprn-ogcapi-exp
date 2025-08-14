
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
  /// The scope of an ISO 639-3 code.
  /// </summary>
  public enum CodeScope {

    /// <summary>
    /// The code is an individual language.
    /// </summary>
    Individual,

    /// <summary>
    /// The code is a macrolanguage.
    /// </summary>
    Macrolanguage,

    /// <summary>
    /// The code is special.
    /// </summary>
    Special

  }

}
