
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
  /// A set of ISO 639-3 codes that have been retired.
  /// </summary>
  public sealed class Iso639Part3Retirement : IIso639 {

    private string _codeId = null!;

    /// <summary>
    /// The three-letter ISO 639-3 identifier.
    /// </summary>
    public required string CodeId {
      get => _codeId;
      set => IIso639.SetIso639CodeId(_codeId, value, requiredCharacters: 3);
    }

    /// <summary>
    /// The reference language name.
    /// </summary>
    public required string ReferenceName {
      get; set;
    }

    /// <summary>
    /// The reason for the retirement. E.g. change, duplicate, merge, non-existent, split.
    /// </summary>
    // TODO: Improve enum values in the documentation
    public required RetirementReason RetirementReason {
      get; set;
    }

    /// <summary>
    /// <para>
    /// Indicates what value the <see cref="CodeId"/> should be changed to.
    /// </para>
    /// <para>
    /// When the <see cref="RetirementReason"/> has the values <see cref="RetirementReason.Change"/>, 
    /// <see cref="RetirementReason.Duplicate"/>, or <see cref="RetirementReason.Merge"/>
    /// the <see cref="CodeId"/> should be changed to this value.
    /// </para>
    /// </summary>
    public string? ChangeTo {
      get; set;
    }

    /// <summary>
    /// The instructions for updating an instance of the retired <see cref="CodeId"/>.
    /// </summary>
    public string? RetirementRemedy {
      get; set;
    }

    /// <summary>
    /// The date the <see cref="CodeId"/> retirement becomes effective.
    /// </summary>
    public required DateTime Effective {
      get; set;
    }

  }

}
