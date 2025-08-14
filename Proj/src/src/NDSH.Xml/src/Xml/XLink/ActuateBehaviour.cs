
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
// <annotation>
//   <documentation>
//        The 'actuate' attribute is used to communicate the desired timing 
//        of traversal from the starting resource to the ending resource; 
//        it's value should be treated as follows:
//        onLoad - traverse to the ending resource immediately on loading 
//                 the starting resource 
//        onRequest - traverse from the starting resource to the ending 
//                    resource only on a post-loading event triggered for 
//                    this purpose 
//        other - behavior is unconstrained; examine other markup in link 
//                for hints 
//        none - behavior is unconstrained
//   </documentation>
// </annotation>
// <simpleType>
//   <restriction base="string">
//     <enumeration value="onLoad"/>
//     <enumeration value="onRequest"/>
//     <enumeration value="other"/>
//     <enumeration value="none"/>
//   </restriction>
// </simpleType>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

#endregion

namespace NDSH.Xml.XLink {

  /// <summary>
  /// The enumeration of the values of the 'actuate' behaviour which is used
  /// to communicate the desired timing of traversal from the starting resource
  /// to the ending resource.
  /// </summary>
  [Serializable]
  //[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/xlink")] // TODO: Should this have a TypeName???
  public enum ActuateBehaviour {

    /// <summary>
    /// Traverse to the ending resource immediately on loading the starting resource.
    /// </summary>
    //[XmlEnum(Name = "onLoad")]
    [EnumMember(Value = "onLoad")]
    OnLoad = 0,

    /// <summary>
    /// Traverse from the starting resource to the ending resource only
    /// on a post-loading event triggered for this purpose.
    /// </summary>
    //[XmlEnum(Name = "onRequest")]
    [EnumMember(Value = "onRequest")]
    OnRequest = 1,

    /// <summary>
    /// Behavior is unconstrained; examine other markup in link for hints.
    /// </summary>
    //[XmlEnum(Name = "other")]
    [EnumMember(Value = "other")]
    Other = 2,

    /// <summary>
    /// Behavior is unconstrained.
    /// </summary>
    //[XmlEnum(Name = "none")]
    [EnumMember(Value = "none")]
    None = 3,

  }

}
