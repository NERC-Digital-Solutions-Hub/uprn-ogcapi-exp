
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
// xlink:actuate is a behavior attribute.
//
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
//
// [XmlAttribute(AttributeName = "actuate", DataType = "string", Namespace = "http://www.w3.org/1999/xlink")]
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
  /// Provides the contract for the <c>xlink:actuate</c> attribute.
  /// </summary>
  public interface IActuate {

    /// <summary>
    ///   <para>
    ///     The <c>xlink:actuate</c> attribute is used to communicate the desired timing of traversal
    ///     from the starting resource to the ending resource.
    ///   </para>
    ///   <para>
    ///     <b>Uses:</b>
    ///     <list type="bullet">
    ///       <item>
    ///         Use the <see cref="ActuateBehaviours"/> static property to access all valid string values
    ///         used in the <see cref="Actuate"/> property.
    ///         Select a valid value using as a key an <see cref="ActuateBehaviour"/> enumerated value.
    ///       </item>
    ///       <item>
    ///         The <c>xlink:actuate</c> attribute controls when and how a linked resource is loaded or activated.
    ///       </item>
    ///     </list>
    ///   </para>
    ///   <para>
    ///   <b>Example:</b>
    ///   <example>
    ///     <code>
    ///       <see cref="Actuate"/> = <see cref="ActuateBehaviours"/>[<see cref="ActuateBehaviour.None"/>]
    ///     </code>
    ///   </example>
    ///   </para>
    /// </summary>
    /// <remarks>The <c>xlink:actuate</c> is a behavior attribute.</remarks>
    public string? Actuate {
      get;
      set;
    }

    /// <summary>
    /// Gets the <see cref="ReadOnlyDictionary{ActuateBehaviour, String}"/> of valid values
    /// used for the <b>Actuate attribute</b> (<see cref="Actuate"/> property),
    /// which determines how a link is triggered.
    /// </summary>
    /// <remarks>
    /// Implementations must provide all the <see cref="string"/> representations
    /// of the <see cref="ActuateBehaviour"/> enumeration values.
    /// </remarks>
    public static readonly ReadOnlyDictionary<ActuateBehaviour, string> ActuateBehaviours =
      new(new Dictionary<ActuateBehaviour, string>(4) {
        // TODO: Fix the nullability problem here.
        { ActuateBehaviour.OnLoad, ActuateBehaviour.OnLoad.GetXmlEnumAttribute() },
        { ActuateBehaviour.OnRequest, ActuateBehaviour.OnRequest.GetXmlEnumAttribute() },
        { ActuateBehaviour.Other, ActuateBehaviour.Other.GetXmlEnumAttribute() },
        { ActuateBehaviour.None,ActuateBehaviour.None.GetXmlEnumAttribute() }
      });

  }

}
