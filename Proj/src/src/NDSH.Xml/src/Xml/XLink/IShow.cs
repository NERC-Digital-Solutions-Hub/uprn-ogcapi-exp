
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
// xlink:show is a behavior attribute.
//
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
//
// [XmlAttribute(AttributeName = "show", DataType = "string", Namespace = "http://www.w3.org/1999/xlink")]
// ---------------------------------------------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// Provides the contract for the <c>xlink:show</c> attribute.
  /// </summary>
  public interface IShow {

    /// <summary>
    ///   <para>
    ///     The <c>xlink:show</c> attribute is used to communicate the desired presentation
    ///     of the ending resource on traversal from the starting resource.
    ///   </para>
    ///   <para>
    ///     <b>Uses:</b>
    ///     <list type="bullet">
    ///       <item>
    ///         Use the <see cref="ShowBehaviours"/> static property to access all valid string values
    ///         used in the <see cref="Show"/> property.
    ///         Select a valid value using as a key an <see cref="ShowBehaviour"/> enumerated value.
    ///       </item>
    ///       <item>
    ///         It is typically used in hyperlink elements to indicate
    ///         how the linked resource should be displayed when activated.
    ///       </item>
    ///     </list>
    ///   </para>
    ///   <para>
    ///     <b>Example:</b>
    ///     <example>
    ///       <code>
    ///         <see cref="Show"/> = <see cref="ShowBehaviours"/>[<see cref="ShowBehaviour.None"/>]
    ///       </code>
    ///     </example>
    ///   </para>
    /// </summary>
    /// <remarks>The <c>xlink:show</c> is a behavior attribute.</remarks>
    public string? Show { // TODO: Determine if a validation attribute can be added here.
      get;
      set;
    }

    /// <summary>
    /// Gets the <see cref="ReadOnlyDictionary{ShowBehaviour, String}"/> of valid values
    /// used for the <b>Show attribute</b> (<see cref="Show"/> property),
    /// which determines how a linked resource should be displayed.
    /// </summary>
    /// <remarks>
    /// Implementations must provide all the <see cref="string"/> representations
    /// of the <see cref="ShowBehaviour"/> enumeration values.
    /// </remarks>
    public static readonly ReadOnlyDictionary<ShowBehaviour, string> ShowBehaviours =
      new(new Dictionary<ShowBehaviour, string>(5) {
        // TODO: fix the nullability problem.
        { ShowBehaviour.New, ShowBehaviour.New.GetXmlEnumAttribute() },
        { ShowBehaviour.Replace, ShowBehaviour.Replace.GetXmlEnumAttribute() },
        { ShowBehaviour.Embed, ShowBehaviour.Embed.GetXmlEnumAttribute() },
        { ShowBehaviour.Other, ShowBehaviour.Other.GetXmlEnumAttribute() },
        { ShowBehaviour.None, ShowBehaviour.None.GetXmlEnumAttribute() }
      });

  }

}
