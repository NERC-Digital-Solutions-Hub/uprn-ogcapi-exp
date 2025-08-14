
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
// xlink:title is a semantic attribute.
// 
// <attribute name="title" type="string"/>
// 
// [XmlAttribute(AttributeName = "title", DataType = "string", Namespace = "http://www.w3.org/1999/xlink")]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// Provides the contract for the <c>xlink:title</c> attribute.
  /// </summary>
  public interface ITitle {

    /// <summary>
    ///   <para>
    ///     The <c>xlink:title</c> is an optional attribute that provides descriptive metadata for a link.
    ///     Its main purpose is to give a human-readable description of the link’s meaning or purpose.
    ///   </para>
    ///   <para>
    ///     <b>Uses:</b>
    ///     <list type="bullet">
    ///       <item>
    ///         It is typically used within elements that support XLink, like &lt;a&gt;,
    ///         &lt;resource&gt;, or &lt;locator&gt; in XML-based languages.
    ///       </item>
    ///       <item>Used in geospatial data to describe linked geographic objects.</item>
    ///       <item>Used in structured documents to describe external resources.</item>
    ///     </list>
    ///   </para>
    /// </summary>
    /// <remarks>The <c>xlink:title</c> is a semantic attribute.</remarks>
    public string? Title {
      get;
      set;
    }

  }

}
