
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Geospatial.Common.Citation.csproj
// Created           : 21/12/2022, @gisvlasta
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using System.Xml.Serialization;

#endregion

namespace NDSH.Apps.Benchmarks.Models {

  /// <summary>
  /// Location of the responsible individual or organisation.
  /// </summary>
  public class CI_Address_Type2 : ObservableModel {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CI_Address_Type2"/>
    /// </summary>
    public CI_Address_Type2() {

      xmlns = new XmlSerializerNamespaces();
      xmlns.Add("gmd", "http://www.isotc211.org/2005/gmd");

      _deliveryPoint = new();
      _city = string.Empty; // new string?();
      _administrativeArea = string.Empty;  // new string?();
      _postalCode = string.Empty;  // new string?();
      _country = string.Empty;  // new string?();
      _electronicMailAddress = new();  // new List<string?>();

    }

    #endregion

    #region Public Fields

    /// <summary>
    /// 
    /// </summary>
    [XmlNamespaceDeclarations()]
    public XmlSerializerNamespaces xmlns;

    #endregion

    #region Public Properties

    private List<string?> _deliveryPoint;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("deliveryPoint", Order = 0)]
    public List<string?> DeliveryPoint {
      get => _deliveryPoint;
      set => SetProperty(ref _deliveryPoint, value);
    }

    private string? _city;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("city", Order = 1)]
    public string? City {
      get => _city;
      set => SetProperty(ref _city, value);
    }

    private string? _administrativeArea;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("administrativeArea", Order = 2)]
    public string? AdministrativeArea {
      get => _administrativeArea;
      set => SetProperty(ref _administrativeArea, value);
    }

    private string? _postalCode;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("postalCode", Order = 3)]
    public string? PostalCode {
      get => _postalCode;
      set => SetProperty(ref _postalCode, value);
    }

    private string? _country;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("country", Order = 4)]
    public string? Country {
      get => _country;
      set => SetProperty(ref _country, value);
    }

    private List<string?> _electronicMailAddress;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("electronicMailAddress", Order = 5)]
    public List<string?> ElectronicMailAddress {
      get => _electronicMailAddress;
      set => SetProperty(ref _electronicMailAddress, value);
    }

    #endregion

  }

}
