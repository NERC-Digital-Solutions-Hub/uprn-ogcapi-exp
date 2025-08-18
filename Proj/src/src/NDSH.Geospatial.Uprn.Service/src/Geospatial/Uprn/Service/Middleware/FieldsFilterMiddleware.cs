using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace NDSH.Geospatial.Uprn.Service.Middleware {

  /// <summary>
  /// Middleware to filter fields from item responses based on the 'fields' query parameter.
  /// </summary>
  public class FieldsFilterMiddleware {

    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="FieldsFilterMiddleware"/> class.
    /// </summary>
    /// <param name="next">Next request.</param>
    public FieldsFilterMiddleware(RequestDelegate next) {
      _next = next;
    }

    /// <summary>
    /// Intercepts the HTTP request and response to filter fields based on the 'fields' query parameter.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>An asynchronous task with the modified response.</returns>
    public async Task InvokeAsync(HttpContext context) {
      // Only intercept /items endpoints
      if (!context.Request.Path.Value.Contains("/items")) {
        await _next(context);
        return;
      }

      // Check if 'fields' query parameter exists
      if (!context.Request.Query.TryGetValue("fields", out var fieldsParam)) {
        await _next(context);
        return;
      }

      var fields = fieldsParam.ToString()
          .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
          .ToHashSet();

      var newQuery = context.Request.Query
        .Where(kvp => kvp.Key != "fields")
        .SelectMany(kvp => kvp.Value, (kvp, val) => new KeyValuePair<string, string?>(kvp.Key, val));
      context.Request.QueryString = QueryString.Create(newQuery);

      // Swap out the response body for a memory stream
      var originalBody = context.Response.Body;
      using var memoryStream = new MemoryStream();
      context.Response.Body = memoryStream;

      await _next(context); // let the OgcApi.Net controller write its response

      memoryStream.Seek(0, SeekOrigin.Begin);
      var jsonDoc = await JsonNode.ParseAsync(memoryStream);

      if (jsonDoc is JsonObject root) {
        if (root.ContainsKey("features")) {
          var features = root["features"] as JsonArray;
          if (features != null) {
            foreach (var feature in features.OfType<JsonObject>()) {
              FilterProperties(feature, fields);
            }
          }
        }
        else {
          FilterProperties(root, fields);
        }
      }

      // Write modified response
      context.Response.Body = originalBody;
      context.Response.ContentType = "application/geo+json";
      await context.Response.WriteAsync(jsonDoc.ToJsonString());

    }

    void FilterProperties(JsonObject feature, HashSet<string> fields) {
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
