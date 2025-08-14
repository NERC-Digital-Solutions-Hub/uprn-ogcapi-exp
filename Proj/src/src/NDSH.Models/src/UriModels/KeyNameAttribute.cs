
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.UriModels {

  /// <summary>
  /// The attribute used to provide the key name as it is used in a URI query parameter or in a header.
  /// </summary>
  /// <remarks>
  /// This is used to mark properties of classes inheriting either
  /// <see cref="QueryParametersModel"/> or <see cref="HeadersModel"/>.
  /// </remarks>
  /// <exception cref="InvalidOperationException">
  /// Thrown when the <see cref="KeyNameAttribute"/> is used on a property that is not in a class
  /// that inherits from <see cref="QueryParametersModel"/> or from <see cref="HeadersModel"/>.
  /// </exception>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public sealed class KeyNameAttribute : Attribute {

    /// <summary>
    /// Gets the key name.
    /// </summary>
    public string KeyName {
      get;
      private set;
    }

    /// <summary>
    /// Initialize the <see cref="KeyNameAttribute"/>.
    /// </summary>
    /// <param name="keyName">
    /// The name of the key it appears in the query parameters or the headers of an URI.
    /// </param>
    public KeyNameAttribute(string keyName) {

      this.KeyName = keyName;

      // Get the class names where this attribute is applied using nameof.
      string queryParametersClassName = nameof(QueryParametersModel);
      string headersClassName = nameof(HeadersModel);

      // Check if the declaring type inherits from QueryParametersModel or HeadersModel.
      bool inherits =
        typeof(QueryParametersModel).IsAssignableFrom(this.GetType().DeclaringType) ||
        typeof(HeadersModel).IsAssignableFrom(this.GetType().DeclaringType);

      if (!inherits) {
        throw new InvalidOperationException(
          $"{nameof(KeyNameAttribute)} can only be used on properties within classes that inherit from {queryParametersClassName} or {headersClassName}." // RESOURCE
        );
      }

    }

  }

}
