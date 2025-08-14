
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Xml.csproj
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
// [
//   XmlAttribute(
//     AttributeName = "type",
//     DataType = "string", Namespace = "http://www.w3.org/1999/xlink", Form = XmlSchemaForm.Qualified)
// ]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// Provides the contract for the <c>type</c> attribute.
  /// </summary>
  public interface IType {

    /// <summary>
    /// Gets the type of the XLink.
    /// </summary>
    public string Type {
      get;
    }

  }

}
