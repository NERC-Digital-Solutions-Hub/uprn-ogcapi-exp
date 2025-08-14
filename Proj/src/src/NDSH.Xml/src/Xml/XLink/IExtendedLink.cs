
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Xml.csproj
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
// XSD               : /2005/xlink/xlinks.xsd
// ---------------------------------------------------------------------------------------------------------------------
// <attribute name="role" type="anyURI"/>
// <attribute name="title" type="string"/>
// <attributeGroup name="extendedLink">
//   <attribute name="type" type="string" fixed="extended" form="qualified"/>
//   <attribute ref="xlink:role" use="optional"/>
//   <attribute ref="xlink:title" use="optional"/>
// </attributeGroup>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  // TODO: Add XML Documentation.
  public interface IExtendedLink : IType, IRole, ITitle {

    // TODO: Add XML Documentation
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "type", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
    string IType.Type => "extended";

  }

}
