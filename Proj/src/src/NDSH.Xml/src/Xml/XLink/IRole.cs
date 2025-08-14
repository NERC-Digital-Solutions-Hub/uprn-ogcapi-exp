
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
// role is a semantic attribute.
// 
// <attribute name="role" type="anyURI"/>
// 
// [XmlAttribute(AttributeName = "role", DataType = "anyURI", Namespace = "http://www.w3.org/1999/xlink")]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// Provides the contract for the <c>xlink:role</c> attribute.
  /// </summary>
  public interface IRole {

    /// <summary>
    ///   <para>
    ///     The <c>xlink:role</c> attribute is used to describe the intended role or purpose of a linked resource.
    ///     Unlike <c>xlink:arcrole</c>, which defines the relationship between two resources,
    ///     <c>xlink:role</c> provides context about the linked resource itself.
    ///   </para>
    ///   <para>
    ///     <b>Uses:</b>
    ///     <list type="bullet">
    ///       <item>
    ///         It is typically used in simple links, extended links,
    ///         and resource definitions to describe what the linked resource represents.
    ///       </item>
    ///       <item>Used to classify linked documents, images, datasets, and multimedia.</item>
    ///       <item>Used in GML (Geography Markup Language) to describe geospatial data roles.</item>
    ///       <item>Used in XBRL (eXtensible Business Reporting Language) to define financial document roles.</item>
    ///     </list>
    ///   </para>
    /// </summary>
    /// <remarks>The <c>xlink:role</c> is a semantic attribute.</remarks>
    public string? Role {
      get;
      set;
    }

  }

}
