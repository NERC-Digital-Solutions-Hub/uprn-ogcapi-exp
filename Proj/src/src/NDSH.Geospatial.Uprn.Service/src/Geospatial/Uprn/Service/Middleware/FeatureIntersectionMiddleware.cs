using global::NetTopologySuite.Features;
using global::NetTopologySuite.Geometries;
using global::NetTopologySuite.IO.Converters;
using global::NetTopologySuite.Operation.Union;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using OgcApi.Net.Features;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NDSH.Geospatial.Uprn.Service.Middleware {
  public class FeatureIntersectionMiddleware {
    private readonly RequestDelegate _next;
    private readonly HttpClient _http;

    public FeatureIntersectionMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory) {
      _next = next;
      _http = httpClientFactory.CreateClient("OgcApi");
    }

    public async Task InvokeAsync(HttpContext context) {
      if (!context.Request.Path.Value.EndsWith("/items")) {
        await _next(context);
        return;
      }

      if (!context.Request.Query.ContainsKey("selectorSource") || !context.Request.Query.ContainsKey("selectorIds")) {
        await _next(context);
        return;
      }

      var selectorSource = context.Request.Query["selectorSource"].ToString();
      var selectorIds = context.Request.Query["selectorIds"].ToString().Split(',').Select(int.Parse).ToList();

      var requestCrs = context.Request.Query.TryGetValue("crs", out StringValues requestCrsVals)
          ? requestCrsVals.ToString()
          : null;
      var requestApiKey = context.Request.Query.TryGetValue("apiKey", out StringValues requestApiKeyVals)
          ? requestApiKeyVals.ToString()
          : null;

      var jsonOptions = context.RequestServices.GetRequiredService<IOptions<JsonOptions>>().Value;
      var jsonSerializerOptions = jsonOptions.SerializerOptions;
      if (!jsonSerializerOptions.Converters.Any(c => c is GeoJsonConverterFactory)) {
        jsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory());
      }

      var resultList = new List<Geometry>();
      foreach (var id in selectorIds) {
        var url = $"{context.Request.Scheme}://{context.Request.Host}/api/ogc/collections/{selectorSource}/items/{id}";
        var selectorQueryString = $"?crs={requestCrs}";
        var selectorIdJson = await _http.GetStringAsync(url + selectorQueryString);
        var feature = JsonSerializer.Deserialize<IFeature>(selectorIdJson, jsonSerializerOptions);

        if (feature != null && feature.Geometry != null) {
          if (feature.Geometry is not IPolygonal) {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync($"Selector feature with ID {id} does not have a polygonal geometry.");
          }
          resultList.Add(feature.Geometry);
        }
      }

      if (!resultList.Any()) {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync("No selector features found for the provided IDs.");
        return;
      }

      var selectorUnion = CascadedPolygonUnion.Union(resultList);

      Envelope overallEnvelope = selectorUnion.EnvelopeInternal;

      if (overallEnvelope == null) {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("No valid geometries found in the provided features.");
        return;
      }

      int requestLimit = context.Request.Query.TryGetValue("limit", out var limitVals) ? int.Parse(limitVals) : 10;
      int requestOffset = context.Request.Query.TryGetValue("offset", out var offsetVals) ? int.Parse(offsetVals) : 0;
      var requestDateTime = context.Request.Query.TryGetValue("datetime", out var dtVals) ? dtVals.ToString() : null;

      var bboxCoordinates = new List<double> { overallEnvelope.MinX, overallEnvelope.MinY, overallEnvelope.MaxX, overallEnvelope.MaxY };
      string bbox = string.Join(',', bboxCoordinates);

      var newQuery = context.Request.Query
        .Where(kvp => kvp.Key != "selectorSource" && kvp.Key != "selectorIds")
        .SelectMany(kvp => kvp.Value, (kvp, val) => new KeyValuePair<string, string?>(kvp.Key, val))
        .Append(new KeyValuePair<string, string?>("bbox", bbox))
        .Append(new KeyValuePair<string, string?>("bbox-crs", requestCrs));
      context.Request.QueryString = QueryString.Create(newQuery);

      var originalBody = context.Response.Body;
      var memoryStream = new MemoryStream();
      context.Response.Body = memoryStream;

      await _next(context);

      memoryStream.Seek(0, SeekOrigin.Begin);
      var featuresInBboxJson = await JsonNode.ParseAsync(memoryStream);

      if (featuresInBboxJson is JsonObject root) {
        if (root.ContainsKey("features")) {
          var featuresArray = root["features"] as JsonArray;
          if (featuresArray != null) {
            foreach (var featureNode in featuresArray.OfType<JsonObject>().ToList()) {
              if (featureNode.TryGetPropertyValue("geometry", out var geometryNode) && geometryNode != null) {
                var featureGeometry = JsonSerializer.Deserialize<Geometry>(geometryNode.ToJsonString(), jsonSerializerOptions);
                if (!selectorUnion.Intersects(featureGeometry)) {
                  featuresArray.Remove(featureNode);
                }
              }
            }
          }
          int featureNumber = featuresArray.Count;
          if (root.ContainsKey("numberMatched")) {
            root["numberMatched"] = featureNumber;
          }
          if (root.ContainsKey("numberReturned")) {
            root["numberReturned"] = featureNumber;
          }
        }
      }

      // Serialize GeoJSON
      context.Response.Body = originalBody; // Restore original response body
      context.Response.ContentType = "application/geo+json";
      await context.Response.WriteAsync(featuresInBboxJson.ToJsonString());
    }
  }
}
