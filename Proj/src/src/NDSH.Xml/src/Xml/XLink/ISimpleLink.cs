
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Xml.csproj
// Created           : 07/03/2025, @gisvlasta
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
// XSD               : /2005/xlink/xlinks.xsd
// ---------------------------------------------------------------------------------------------------------------------
// <attribute name="href" type="anyURI"/>
// <attribute name="role" type="anyURI"/>
// <attribute name="arcrole" type="anyURI"/>
// <attribute name="title" type="string"/>
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
// <attributeGroup name="simpleLink">
//   <attribute name="type" type="string" fixed="simple" form="qualified"/>
//   <attribute ref="xlink:href" use="optional"/>
//   <attribute ref="xlink:role" use="optional"/>
//   <attribute ref="xlink:arcrole" use="optional"/>
//   <attribute ref="xlink:title" use="optional"/>
//   <attribute ref="xlink:show" use="optional"/>
//   <attribute ref="xlink:actuate" use="optional"/>
// </attributeGroup>
// 
// [
//   XmlAttribute(AttributeName = "type",
//   DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")
// ]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  ///   <para>
  ///     Provides the contract for the <c>xlink:href</c> attribute.
  ///   </para>
  ///   <para>
  ///     The <c>xlink:simpleLink</c> attribute group defines a set of standard attributes for simple links
  ///     in XML-based documents. It provides metadata and behavior control for linked resources.
  ///   </para>
  ///   <para>
  ///     <b>Uses:</b>
  ///     <list type="bullet">
  ///       It is used in hyperlinks, metadata references, geospatial data (GML), SVG, and financial reports (XBRL).
  ///     </list>
  ///   </para>
  /// </summary>
  public interface ISimpleLink : IType, IHref, IRole, IArcRole, ITitle, IShow, IActuate {

    /// <summary>
    /// Gets the type of the XLink which in this case is the string constant <c>"simple"</c>.
    /// </summary>
    string IType.Type => "simple";

  }

}
