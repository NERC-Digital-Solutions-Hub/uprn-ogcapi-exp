
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
// arcrole is a semantic attribute.
// 
// <attribute name="arcrole" type="anyURI"/>
// 
// //[XmlAttribute(AttributeName = "arcrole", DataType = "anyURI", Namespace = "http://www.w3.org/1999/xlink")]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// Provides the contract for the <c>xlink:arcrole</c> attribute.
  /// </summary>
  public interface IArcRole {

    /// <summary>
    ///   <para>
    ///     The <c>xlink:arcrole</c> attribute is used to classify or specify the function
    ///     of a link in a machine-readable way. It holds a URI that provides semantic meaning
    ///     to the relationship between resources.
    ///   </para>
    ///   <para>
    ///     <b>Uses:</b>
    ///     <list type="bullet">
    ///       <item>
    ///         The <c>xlink:arcrole</c> attribute is typically used in extended links and arcs
    ///         to define the nature of relationships between linked resources.
    ///       </item>
    ///       <item>
    ///         Used to categorize links in structured XML documents, like financial data,
    ///         legal references, or scientific publications.
    ///       </item>
    ///       <item>
    ///         Used in GIS applications to define topological relationships
    ///         (e.g., "is next to," "contains," "overlaps").
    ///       </item>
    ///       <item>Used in financial reporting to define relationships between accounting concepts.</item>
    ///     </list>
    ///   </para>
    /// </summary>
    /// <remarks>The <c>xlink:arcrole</c> is a semantic attribute.</remarks>
    public string? ArcRole {
      get;
      set;
    }

  }

}
