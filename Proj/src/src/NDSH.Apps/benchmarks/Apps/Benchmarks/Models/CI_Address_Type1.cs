
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
  public class CI_Address_Type1 : ObservableModel {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CI_Address_Type1"/>
    /// </summary>
    public CI_Address_Type1() {

      xmlns = new XmlSerializerNamespaces();
      xmlns.Add("gmd", "http://www.isotc211.org/2005/gmd");

      _deliveryPoint = new();
      _city = string.Empty; // new string();
      _administrativeArea = string.Empty;  // new string();
      _postalCode = string.Empty;  // new string();
      _country = string.Empty;  // new string();
      _electronicMailAddress = new();  // new List<string>();

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
      set {
        if (_deliveryPoint == value) {
          return;
        }

        if (_deliveryPoint == null || !_deliveryPoint.Equals(value)) {
          _deliveryPoint = value;
          OnPropertyChanged();
        }
      }
    }

    private string? _city;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("city", Order = 1)]
    public string? City {
      get => _city;
      set {
        if (_city == value) {
          return;
        }
        if (_city == null || !_city.Equals(value)) {
          _city = value;
          OnPropertyChanged();
        }
      }
    }

    private string? _administrativeArea;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("administrativeArea", Order = 2)]
    public string? AdministrativeArea {
      get => _administrativeArea;
      set {
        if (_administrativeArea == value) {
          return;
        }
        if (_administrativeArea == null || !_administrativeArea.Equals(value)) {
          _administrativeArea = value;
          OnPropertyChanged();
        }
      }
    }

    private string? _postalCode;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("postalCode", Order = 3)]
    public string? PostalCode {
      get => _postalCode;
      set {
        if (_postalCode == value) {
          return;
        }
        if (_postalCode == null || !_postalCode.Equals(value)) {
          _postalCode = value;
          OnPropertyChanged();
        }
      }
    }

    private string? _country;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("country", Order = 4)]
    public string? Country {
      get => _country;
      set {
        if (_country == value) {
          return;
        }

        if (_country == null || !_country.Equals(value)) {
          _country = value;
          OnPropertyChanged();
        }
      }
    }

    private List<string?> _electronicMailAddress;

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("electronicMailAddress", Order = 5)]
    public List<string?> ElectronicMailAddress {
      get => _electronicMailAddress;
      set {
        if (_electronicMailAddress == value) {
          return;
        }

        if (_electronicMailAddress == null || !_electronicMailAddress.Equals(value)) {
          _electronicMailAddress = value;
          OnPropertyChanged();
        }
      }
    }

    #endregion

  }

}
