using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Services;
using OgcApi.Net.OpenApi;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NDSH.Geospatial.Uprn.Service.Middleware {
  /// <summary>
  /// Middleware to intercept the Swagger JSON generation, add 'fields' query parameter to /items endpoints,
  /// and serve a cached modified JSON.
  /// </summary>
  public class SwaggerJsonModifierMiddleware {
    private readonly RequestDelegate _next;
    private readonly IOpenApiGenerator _generator;
    private readonly string _swaggerPath;
    private string? _cachedJson;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwaggerJsonModifierMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="generator">The generator creating the swagger.json</param>
    /// <param name="swaggerPath">The path the json is served through.</param>
    public SwaggerJsonModifierMiddleware(RequestDelegate next, IOpenApiGenerator generator, string swaggerPath) {
      _next = next;
      _generator = generator;
      _swaggerPath = swaggerPath;
    }

    /// <summary>
    /// Intercepts the HTTP request to serve a modified Swagger JSON with 'fields' parameter added to /items endpoints.
    /// </summary>
    /// <param name="context">Contains metadata of the request.</param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context) {
      if (!context.Request.Path.Value.Equals(_swaggerPath, StringComparison.OrdinalIgnoreCase)) {
        await _next(context);
        return;
      }

      if (_cachedJson == null) {
        var baseUri = new Uri($"{context.Request.Scheme}://{context.Request.Host}/api/ogc");
        var doc = _generator.GetDocument(baseUri);

        // Add 'fields' query parameter to /items and /items/{id} paths
        foreach (var pathKvp in doc.Paths.Where(p => p.Key.Contains("/items"))) {
          var pathItem = pathKvp.Value;
          foreach (var op in pathItem.Operations.Values) {
            op.Parameters ??= new List<OpenApiParameter>();
            if (!op.Parameters.Any(p => p.Name == "fields")) {
              op.Parameters.Add(new OpenApiParameter {
                Name = "fields",
                In = ParameterLocation.Query,
                Description = "Comma-separated list of properties to include in the response",
                Required = false
              });
            }
          }
        }
        foreach (var pathKvp in doc.Paths.Where(p => p.Key.EndsWith("/items"))) {
          var pathItem = pathKvp.Value;
          foreach (var op in pathItem.Operations.Values) {
            if (!op.Parameters.Any(p => p.Name == "selectorSource")) {
              op.Parameters.Add(new OpenApiParameter {
                Name = "selectorSource",
                In = ParameterLocation.Query,
                Description = "The source endpoint of features to use for selecting from the queried endpoint, e.g., 'evi-cells'. Only endpoints returning IPolygonal features will work.",
                Required = false
              });
            }
            if (!op.Parameters.Any(p => p.Name == "selectorIds")) {
              op.Parameters.Add(new OpenApiParameter {
                Name = "selectorIds",
                In = ParameterLocation.Query,
                Description = "Comma-separated list of IDs from the source endpoint to select features from the queried endpoint",
                Required = false
              });
            }
          }
        }

        _cachedJson = doc.SerializeAsJson(Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);
      }

      context.Response.ContentType = "application/json";
      await context.Response.WriteAsync(_cachedJson);
    }
  }
}
