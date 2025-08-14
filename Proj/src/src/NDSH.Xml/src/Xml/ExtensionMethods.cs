
#region Header
// --------------------------------------------------------------------------------
// Member of         : NDSH.Xml.csproj
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// --------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

#endregion

namespace NDSH.Xml {

  /// <summary>
  /// The ExtensionMethods class provides utility extension methods.
  /// </summary>
  public static class ExtensionMethods {

    /// <summary>
    /// Gets the XML enum name for the specified <see cref="Enum"/> value if defined 
    /// by an <see cref="XmlEnumAttribute"/>, otherwise returns the enum's standard name.
    /// </summary>
    /// <typeparam name="T">An enumeration type.</typeparam>
    /// <param name="enumValue">The enumeration value.</param>
    /// <returns>
    /// A <see cref="string"/> containing either the <see cref="XmlEnumAttribute"/> name of 
    /// the specified <typeparamref name="T"/> value or the enum’s default name 
    /// if no attribute is present.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the provided value is not an <see cref="Enum"/>.
    /// </exception>
    /// <remarks>
    /// This method determines whether the provided enumeration value is decorated with 
    /// an <see cref="XmlEnumAttribute"/>. If so, it returns the attribute’s name; 
    /// otherwise, it returns the enum’s intrinsic name.
    /// </remarks>
    public static string GetXmlEnumAttributeOrName<T>(this T enumValue) where T : struct, IConvertible {

      // Ensure the type is actually an enum.
      Type type = enumValue.GetType();
      if (!type.IsEnum) {
        throw new ArgumentException("The provided value must be an enumeration.", nameof(enumValue)); // RESOURCE
      }

      // Get the enum's intrinsic name as a fallback.
      // For example, MyEnum.ValueOne => "ValueOne".
      string enumName = Enum.GetName(type, enumValue) ?? string.Empty;

      // Attempt to retrieve the XmlEnumAttribute from the appropriate field.
      FieldInfo? fieldInfo = type.GetField(enumName);
      if (fieldInfo != null) {
        // Get any XmlEnumAttributes present on this field.
        object[] xmlEnumAttributes = fieldInfo.GetCustomAttributes(typeof(XmlEnumAttribute), false);

        if (xmlEnumAttributes is { Length: > 0 }) {
          XmlEnumAttribute xmlEnumAttribute = (XmlEnumAttribute)xmlEnumAttributes[0];
          if (!string.IsNullOrEmpty(xmlEnumAttribute.Name)) {
            enumName = xmlEnumAttribute.Name;
          }
        }
      }

      return enumName;

    }

    /// <summary>
    /// Gets the XML enum name defined by the <see cref="XmlEnumAttribute"/> that decorates 
    /// the specified <see cref="Enum"/> value. If the attribute is not present, an exception is thrown.
    /// </summary>
    /// <typeparam name="T">An enumeration type.</typeparam>
    /// <param name="enumValue">The enumeration value.</param>
    /// <returns>
    /// The name specified in the <see cref="XmlEnumAttribute"/> for the given <paramref name="enumValue"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <typeparamref name="T"/> is not an enumeration type.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the <see cref="XmlEnumAttribute"/> is missing for the specified enumeration value.
    /// </exception>
    public static string GetXmlEnumAttribute<T>(this T enumValue) where T : struct, IConvertible {

      // Ensure the type is actually an enum.
      Type type = enumValue.GetType();
      if (!type.IsEnum) {
        throw new ArgumentException("The provided value must be an enumeration.", nameof(enumValue)); // RESOURCE
      }

      // Retrieve the enum's intrinsic name (e.g., "ValueOne").
      string enumName = Enum.GetName(type, enumValue) ?? string.Empty;

      // Get the FieldInfo for that name.
      FieldInfo? fieldInfo = type.GetField(enumName) ??
        throw new InvalidOperationException($"No field information found for the enum value '{enumValue}'."); // RESOURCE

      // Get any XmlEnumAttributes present on this field.
      object[] xmlEnumAttributes = fieldInfo.GetCustomAttributes(typeof(XmlEnumAttribute), false);

      // Throw if none were found.
      if (xmlEnumAttributes.Length == 0) {
        throw new InvalidOperationException($"No XmlEnumAttribute is defined for the enum value '{enumValue}'."); // RESOURCE
      }

      // Return the attribute's name.
      XmlEnumAttribute xmlEnumAttribute = (XmlEnumAttribute)xmlEnumAttributes[0];

      // WARNING: Take care of the null reference.
      return xmlEnumAttribute.Name;

    }

  }

}
