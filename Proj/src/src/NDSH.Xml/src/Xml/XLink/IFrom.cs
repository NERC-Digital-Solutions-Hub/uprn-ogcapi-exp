
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
// <attribute name="from" type="string"/>
// ---------------------------------------------------------------------------------------------------------------------
#endregion

namespace NDSH.Xml.XLink {

  // TODO: Add XML Documentation
  public interface IFrom {

    // TODO: Add XML Documentation.
    // Does it need an XmlAttribute?
    //[XmlAttribute(AttributeName = "from", DataType = "string", Namespace = "http://www.w3.org/1999/xlink")]
    public string From {
      get;
      set;
    }

  }

}
