using System.Text.Json.Nodes;

namespace NDSH.Geospatial.Uprn.Service.Middleware.Utils {
  public static class MiddlewareUtils {

    public static void FilterProperties(JsonObject feature, HashSet<string> fields) {
      if (feature.ContainsKey("properties") && feature["properties"] is JsonObject props) {
        foreach (var key in props.Select(p => p.Key).ToList()) {
          if (!fields.Contains(key)) {
            props.Remove(key);
          }
        }
      }
    }
  }
}
