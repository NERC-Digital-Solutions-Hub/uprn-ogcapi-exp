using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using NetTopologySuite.IO.Converters;
using System.Text.Json.Nodes;

namespace NDSH.Geospatial.Uprn.Service.Middleware {
  public class UprnRelationsMiddleware {

    private readonly RequestDelegate _next;
    private readonly HttpClient _http;

    public UprnRelationsMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory) {
      _next = next;
      _http = httpClientFactory.CreateClient("OgcApi");
    }

    public async Task InvokeAsync(HttpContext context) {

      if (!context.Request.Path.Value.Contains("/uprn/items/")) {
        await _next(context);
        return;
      }

      if (!context.Request.Query.ContainsKey("relationSources")) {
        await _next(context);
        return;
      }

      var relationSources = context.Request.Query["relationSources"].ToString().Split(',').Select(s => s.Trim()).ToList();

      var requestCrs = context.Request.Query.TryGetValue("crs", out StringValues requestCrsVals)
        ? requestCrsVals.ToString()
        : null;

      var newQuery = context.Request.Query
        .Where(kvp => kvp.Key != "relationSources")
        .SelectMany(kvp => kvp.Value, (kvp, val) => new KeyValuePair<string, string?>(kvp.Key, val));
      context.Request.QueryString = QueryString.Create(newQuery);

      string uprn;

      var originalBody = context.Response.Body;
      using var memoryStream = new MemoryStream();
      context.Response.Body = memoryStream;

      await _next(context);
      await context.Response.Body.FlushAsync();

      // memoryStream.Seek(0, SeekOrigin.Begin);
      memoryStream.Position = 0;
      using var reader = new StreamReader(memoryStream, leaveOpen: true);
      var responseString = await reader.ReadToEndAsync();
      memoryStream.Position = 0;
      var jsonDoc = JsonNode.Parse(responseString);

      if (jsonDoc is JsonObject root) {
        if (!root.ContainsKey("properties")) {
          throw new ArgumentException("Could not find properties in response");
        }
        try {
          uprn = root["properties"]["uprn"].ToString();
        }
        catch {
          throw new ArgumentException("Could not find UPRN in response");
        }
      }
      else {
        throw new ArgumentException("Could not find UPRN in response");
      }
      
      var jsonOptions = context.RequestServices.GetRequiredService<IOptions<JsonOptions>>().Value;
      var jsonSerializerOptions = jsonOptions.SerializerOptions;
      if (!jsonSerializerOptions.Converters.Any(c => c is GeoJsonConverterFactory)) {
        jsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory());
      }

      var relationResults = new JsonObject();
      for (int i = 0; i < relationSources.Count; i++) {
        var url = $"{context.Request.Scheme}://{context.Request.Host}/api/ogc/collections/{relationSources[i]}/items/{uprn}";
        var relationResultString = await _http.GetStringAsync(url);
        if (relationResultString == null) {
          relationResults[relationSources[i]] = null;
          continue;
        }
        var relationResultJson = JsonNode.Parse(relationResultString) as JsonObject;
        try {
          relationResults[relationSources[i]] = relationResultJson["properties"].DeepClone();
        }
        catch {
          relationResults[relationSources[i]] = null;
        }
      }

      jsonDoc["relations"] = relationResults;

      context.Response.Body = originalBody;
      context.Response.ContentType = "application/geo+json";
      await context.Response.WriteAsync(jsonDoc.ToJsonString());
    }
  }
}
