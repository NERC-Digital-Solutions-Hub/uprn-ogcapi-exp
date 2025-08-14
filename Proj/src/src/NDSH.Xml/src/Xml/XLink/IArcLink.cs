
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
// <attribute name="arcrole" type="anyURI"/>
// <attribute name="title" type="string"/>
// <attribute name="from" type="string"/>
// <attribute name="to" type="string"/>
// <attribute name="show">
//   <simpleType>
//     <restriction base="string">
//       <enumeration value="new"/>
//       <enumeration value="replace"/>
//       <enumeration value="embed"/>
//       <enumeration value="other"/>
//       <enumeration value="none"/>
//     </restriction>
//   </simpleType>
// </attribute>
// <attribute name="actuate">
//   <simpleType>
//     <restriction base="string">
//       <enumeration value="onLoad"/>
//       <enumeration value="onRequest"/>
//       <enumeration value="other"/>
//       <enumeration value="none"/>
//     </restriction>
//   </simpleType>
// </attribute>
// <attributeGroup name="arcLink">
//   <attribute name="type" type="string" fixed="arc" form="qualified"/>
//   <attribute ref="xlink:arcrole" use="optional"/>
//   <attribute ref="xlink:title" use="optional"/>
//   <attribute ref="xlink:show" use="optional"/>
//   <attribute ref="xlink:actuate" use="optional"/>
//   <attribute ref="xlink:from" use="optional"/>
//   <attribute ref="xlink:to" use="optional"/>
// </attributeGroup>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  public interface IArcLink : IType, IArcRole, ITitle, IShow, IActuate, IFrom, ITo {

    // TODO: Add XML Documentation
    // TODO: Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "type", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
    string IType.Type => "arc";

  }

}
