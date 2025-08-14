
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
  /// A macrolanguage and its members of ISO 639-3 codes.
  /// </summary>
  public sealed class Iso639Part3Macrolanguage : IIso639 {

    private string _macrolanguageCodeId = null!;

    /// <summary>
    /// The three-letter ISO 639-3 identifier for a macrolanguage.
    /// </summary>
    public required string MacrolanguageCodeId {
      get => _macrolanguageCodeId;
      set => IIso639.SetIso639CodeId(_macrolanguageCodeId, value, requiredCharacters: 3);
    }

    private string _memberCodeId = null!;

    /// <summary>
    /// The three-letter ISO 639-3 identifier for a member of the macrolanguage.
    /// </summary>
    public required string MemberCodeId {
      get => _memberCodeId;
      set => IIso639.SetIso639CodeId(_memberCodeId, value, requiredCharacters: 3);
    }

    /// <summary>
    /// The status of the member in the macrolanguage. Either active or retired.
    /// </summary>
    public required CodeStatus MemberCodeStatus {
      get; set;
    }

  }

}
