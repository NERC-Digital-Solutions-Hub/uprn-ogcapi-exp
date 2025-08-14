
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Xml.XLink.csproj
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
// <attribute name="label" type="string"/>
// <attributeGroup name="resourceLink">
//   <attribute name="type" type="string" fixed="resource" form="qualified"/>
//   <attribute ref="xlink:role" use="optional"/>
//   <attribute ref="xlink:title" use="optional"/>
//   <attribute ref="xlink:label" use="optional"/>
// </attributeGroup>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  // TODO: Add XML Documentation.
  public interface IResourceLink : IType, IRole, ITitle, ILabel {

    // TODO: Add XML Documentation.
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "type", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
    string IType.Type => "resource";

  }

}
