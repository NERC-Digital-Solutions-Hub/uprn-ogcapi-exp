
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
  /// A name index for language names variations of ISO 639-3 codes.
  /// </summary>
  public sealed class Iso639Part3NameIndex : IIso639 {

    private string _codeId = null!;

    /// <summary>
    /// The three-letter ISO 639-3 identifier.  
    /// </summary>
    public required string CodeId {
      get => _codeId;
      set => IIso639.SetIso639CodeId(_codeId, value, requiredCharacters: 3);
    }

    /// <summary>
    /// One of the names associated with the <see cref="CodeId"/>.
    /// </summary>
    public required string PrintName {
      get; set;
    }

    /// <summary>
    /// The inverted form of the <see cref="PrintName"/>.
    /// </summary>
    public required string InvertedName {
      get; set;
    }

  }

}
