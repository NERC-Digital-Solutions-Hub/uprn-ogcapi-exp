
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
  /// A set of ISO 639-3 codes.
  /// </summary>
  public sealed class Iso639Part3CodeSet : IIso639 {

    private string _codeId = null!; // WARNING: Why does the IDE recommend that _codeId should be marked as readonly? Maybe SetIso639CodeId() using `ref field` ???

    /// <summary>
    /// The three-letter ISO 639-3 identifier.
    /// </summary>
    public required string CodeId {
      get => _codeId;
      set => IIso639.SetIso639CodeId(_codeId, value, requiredCharacters: 3);
      //set => IIso639.SetIso639CodeIdByRef(ref _codeId, value, requiredCharacters: 3); // TODO: Is this what should be used?
    }

    private string? _code2BId; // WARNING: Why does the IDE recommend that _codeId should be marked as readonly? Maybe SetIso639CodeId() using `ref field` ???

    /// <summary>
    /// The equivalent <see cref="CodeId"/> in ISO 639-2 for bibliographic applications code set.
    /// </summary>
    public string? Code2BId {
      get => _code2BId;
      set => IIso639.SetIso639CodeId(_code2BId, value, requiredCharacters: 3, isNullable: true);
      //set => IIso639.SetIso639CodeIdByRef(ref _code2BId, value, requiredCharacters: 3, isNullable: true); // TODO: Is this what should be used?
    }

    private string? _code2TId; // WARNING: Why does the IDE recommend that _codeId should be marked as readonly? Maybe SetIso639CodeId() using `ref field` ???

    /// <summary>
    /// The equivalent <see cref="CodeId"/> in ISO 639-2 for terminology applications code set.
    /// </summary>
    public string? Code2TId {
      get => _code2TId;
      set => IIso639.SetIso639CodeId(_code2TId, value, requiredCharacters: 3, isNullable: true);
      //set => IIso639.SetIso639CodeIdByRef(ref _code2TId, value, requiredCharacters: 3, isNullable: true); // TODO: Is this what should be used?
    }

    private string? _code1Id; // WARNING: Why does the IDE recommend that _codeId should be marked as readonly? Maybe SetIso639CodeId() using `ref field` ???

    /// <summary>
    /// The equivalent <see cref="CodeId"/> in ISO 639-1.
    /// </summary>
    public string? Code1Id {
      get => _code1Id;
      set => IIso639.SetIso639CodeId(_code1Id, value, requiredCharacters: 2, isNullable: true);
      //set => IIso639.SetIso639CodeIdByRef(ref _code1Id, value, requiredCharacters: 2, isNullable: true); // TODO: Is this what should be used?
    }

    /// <summary>
    /// The scope of the ISO 639-3 code. E.g. individual, macrolanguage, and special.
    /// </summary>
    // TODO: eg individual, macrolanguage, and special use lower case representations of the CodeScope values. Should it be or it needs an improved documentation?
    // TODO: Improve enum values and formatting in the documentation
    public required CodeScope Scope {
      get; set;
    }

    /// <summary>
    /// The type of the code language. E.g. ancient, constructed, extinct, historical, living, special.
    /// </summary>
    // TODO: E.g. are all lower case. Should it be or it needs an improved documentation?
    // TODO: Improve enum values and formatting in the documentation
    public required CodeType Type {
      get; set;
    }

    /// <summary>
    /// The reference language name.
    /// </summary>
    public required string ReferenceName {
      get; set;
    }

    /// <summary>
    /// A comment relating to any of the fields.
    /// </summary>
    public string? Comment {
      get; set;
    }

  }

}
