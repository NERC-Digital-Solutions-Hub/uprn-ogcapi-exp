
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
// <attributeGroup name="titleLink">
//   <attribute name="type" type="string" fixed="title" form="qualified"/>
// </attributeGroup>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  // TODO: Add XML Documentation.
  public interface ITitleLink : IType {

    // TODO: Add XML Documentation.
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "type", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
    string IType.Type => "title";

  }

}
