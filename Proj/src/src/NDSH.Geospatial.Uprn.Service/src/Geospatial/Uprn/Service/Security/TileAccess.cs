using NetTopologySuite.Features;

namespace NDSH.Geospatial.Uprn.Service.Security {
  /// <summary>
  /// Controls access to tiles and features based on the existence of the appropriate API key.
  /// </summary>
  public static class TileAccess {

    /// <summary>
    /// Controls access to tiles based on API key.
    /// </summary>
    /// <param name="collectionId">Identifier of the requested collection.</param>
    /// <param name="tileMatrix"></param>
    /// <param name="tileRow"></param>
    /// <param name="tileCol"></param>
    /// <param name="apiKey"></param>
    /// <returns></returns>
    public static bool TilesAccessDelegate(string collectionId, int tileMatrix, int tileRow, int tileCol, string apiKey) => (collectionId ?? "") switch {
      "PolygonsWithApiKey" when (apiKey ?? "").Equals("qwerty") && tileMatrix is >= 0 and <= 7 =>
          tileMatrix switch {
            0 => tileRow == 0 && tileCol == 0,
            1 => tileRow == 0 && tileCol == 1,
            2 => tileRow == 1 && tileCol == 2,
            3 => tileRow == 2 && tileCol == 5,
            4 => tileRow == 5 && tileCol == 10,
            5 => tileRow == 10 && tileCol == 20,
            6 => tileRow == 20 && tileCol == 40,
            7 => tileRow == 40 && tileCol is 81 or 82,
            _ => false
          },
      _ => true,
    };


    /// <summary>
    /// Controls access to features based on API key and feature attributes.
    /// </summary>
    /// <param name="collectionId">The identifier of the collection requested.</param>
    /// <param name="feature">The feature access is requested to.</param>
    /// <param name="apiKey">The API key.</param>
    /// <returns>Boolean value if the feature can be accessed by the request.</returns>
    public static bool FeatureAccessDelegate(string collectionId, IFeature feature, string apiKey) => (collectionId ?? "") switch {
      "FeatureAccessData" => apiKey == "admin" ||
          apiKey == "value" && feature.Attributes.Exists("value") &&
          (feature.Attributes["value"] is long and > 1200 ||
          feature.Attributes["value"] is > 100.0) ||
          feature.Attributes.Exists("roleAccess") && feature.Attributes["roleAccess"].ToString() == apiKey,
      _ => true,
    };
  }
}
