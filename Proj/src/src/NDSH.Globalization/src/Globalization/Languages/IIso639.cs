
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

#region Imported Namespaces

using System.Runtime.CompilerServices;

#endregion

namespace NDSH.Globalization.Languages {

  /// <summary>
  /// The ISO 639 standard for language codes.
  /// </summary>
  public interface IIso639 {

    /// <summary>
    /// Sets the ISO 639 code identifier.
    /// </summary>
    /// <param name="field">The code identifier field.</param>
    /// <param name="value">The code identifier new value.</param>
    /// <param name="requiredCharacters">
    /// The required number of characters for the code identifier.
    /// </param>
    /// <param name="isNullable">
    /// A <see cref="bool"/> indicating if the field is nullable.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if value is not equal to required characters.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected static void SetIso639CodeId(
      string? field, string? value, int requiredCharacters, bool isNullable = false // WARNING: Shouldn't field be called by ref ???
    ) {
      field = (isNullable && value == null) || value?.Length == requiredCharacters
                ? value
                : throw new ArgumentException($"The code identifier must be {requiredCharacters} characters long."); // RESOURCE
    }

    // TODO: Added here a by ref implementation. Is this valid?
    protected static void SetIso639CodeIdByRef(
      ref string? field, string? value, int requiredCharacters, bool isNullable = false
    ) {
      field = (isNullable && value == null) || value?.Length == requiredCharacters
                ? value
                : throw new ArgumentException($"The code identifier must be {requiredCharacters} characters long."); // RESOURCE
    }

  }

}
