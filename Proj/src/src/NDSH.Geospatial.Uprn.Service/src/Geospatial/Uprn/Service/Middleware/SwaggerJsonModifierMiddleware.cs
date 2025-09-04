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

        // Add 'fields' query parameter to /items and /items/{featureId} endpoints
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
        // Add 'selectorSource', 'selectorIds', and 'compress' query parameters to /items endpoints
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
            if (!op.Parameters.Any(p => p.Name == "compress")) {
              op.Parameters.Add(new OpenApiParameter {
                Name = "compress",
                In = ParameterLocation.Query,
                Description = "If set to 'true', the response will be compressed using GZip and served as a downloadable file. Use this for large responses.",
                Required = false
              });
            }
          }
        }

        // Add relationSources to uprn/items/{featureId} endpoint
        foreach (var pathKvp in doc.Paths.Where(p => p.Key.Contains("/uprn/items/"))) {
          var pathItem = pathKvp.Value;
          foreach (var op in pathItem.Operations.Values) {
            if (!op.Parameters.Any(p => p.Name == "relationSources")) {
              op.Parameters.Add(new OpenApiParameter {
                Name = "relationSources",
                In = ParameterLocation.Query,
                Description = "Comma-separated list of relation sources to include related features from, e.g., 'carbon-values-uprn, evi-values-uprn'. Available for endpoints querying UPRN-based views.",
                Required = false
              });
            }
            if (!op.Parameters.Any(p => p.Name == "relationSourceFields")) {
              op.Parameters.Add(new OpenApiParameter {
                Name = "relationSourceFields",
                In = ParameterLocation.Query,
                Description = "Semicolon-separated list of comma-separated lists of fields to be included in the response for each relation. For example 'uprn,corcoef,grainsize;uprn,moistcoverweight90,moistcoverweightdiff'. Works only if relationSources is specified and the semicolon-separated lists must be in the same order as the relationSources.",
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
