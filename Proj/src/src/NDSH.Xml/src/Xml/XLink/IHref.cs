
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
// href is a locator attribute.
// 
// <attribute name="href" type="anyURI"/>
// 
// [XmlAttribute(AttributeName = "href", DataType = "anyURI", Namespace = "http://www.w3.org/1999/xlink")]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// Provides the contract for the <c>xlink:href</c> attribute.
  /// </summary>
  public interface IHref {

    /// <summary>
    ///   <para>
    ///     The <c>xlink:href</c> attribute is used to define the target of a hyperlink in XML-based documents.
    ///     It works similarly to the href attribute in HTML but is used in a more structured way within XML.
    ///   </para>
    ///   <para>
    ///     <b>Uses:</b>
    ///     <list type="bullet">
    ///       <item>
    ///         It is used to link external resources such as web pages, images, datasets,
    ///         or documents within XML-based formats like SVG, GML (Geospatial Markup Language),
    ///         and XBRL (Financial Reporting).
    ///       </item>
    ///       <item>Used in structured metadata to point to external datasets, images, or documents.</item>
    ///       <item>Used to reference geographic features in GIS (Geospatial Information Systems).</item>
    ///       <item>Used in financial reporting to link definitions, schemas, or taxonomies.</item>
    ///     </list>
    ///   </para>
    /// </summary>
    /// <remarks>The <c>xlink:href</c> is a locator attribute.</remarks>
    public string? Href {
      get;
      set;
    }

  }

}
