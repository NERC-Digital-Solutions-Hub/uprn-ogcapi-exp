
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
// <attribute name="href" type="anyURI"/>
// <attribute name="role" type="anyURI"/>
// <attribute name="title" type="string"/>
// <attribute name="label" type="string"/>
// <attributeGroup name="locatorLink">
//   <attribute name="type" type="string" fixed="locator" form="qualified"/>
//   <attribute ref="xlink:href" use="required"/>
//   <attribute ref="xlink:role" use="optional"/>
//   <attribute ref="xlink:title" use="optional"/>
//   <attribute ref="xlink:label" use="optional"/>
// </attributeGroup>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Xml.XLink {

  // TODO: Add XML Documentation.
  public interface ILocatorLink : IType, IHref, IRole, ITitle, ILabel {

    // TODO: Add XML Documentation.
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "type", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
    string IType.Type => "locator";

    // TODO: Add XML Documentation.
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "href", DataType = "anyURI", Namespace = "http://www.w3.org/1999/xlink")]
    [Required()] // TODO: Should the 'Required' attribute be put at the interface level?
    public new string Href {
      get;
      set;
    }

  }

}
