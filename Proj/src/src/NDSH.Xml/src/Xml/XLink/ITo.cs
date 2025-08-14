
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
// <attribute name="to" type="string"/>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  // TODO: Add XML Documentation.
  public interface ITo {

    // TODO: Add XML Documentation.
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "to", DataType = "string", Namespace = "http://www.w3.org/1999/xlink")]
    public string To {
      get;
      set;
    }

  }

}
