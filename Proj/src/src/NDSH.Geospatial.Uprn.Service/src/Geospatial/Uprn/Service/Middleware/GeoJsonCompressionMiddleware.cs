using System.IO.Compression;

namespace NDSH.Geospatial.Uprn.Service.Middleware {
  public class GeoJsonCompressionMiddleware {

    private readonly RequestDelegate _next;

    public GeoJsonCompressionMiddleware(RequestDelegate next) {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {

      if (!context.Request.Path.Value.EndsWith("/items")) {
        await _next(context);
        return;
      }

      if (!context.Request.Query.TryGetValue("compress", out var compress) || compress != "true") {
        await _next(context);
        return;
      }

      var newQuery = context.Request.Query
        .Where(kvp => kvp.Key != "compress")
        .SelectMany(kvp => kvp.Value, (kvp, val) => new KeyValuePair<string, string?>(kvp.Key, val));
      context.Request.QueryString = QueryString.Create(newQuery);

      var originalBody = context.Response.Body;
      var memoryStream = new MemoryStream();
      context.Response.Body = memoryStream;

      await _next(context);

      memoryStream.Seek(0, SeekOrigin.Begin);

      await using var gzipStream = new MemoryStream();
      await using (var compressor = new GZipStream(gzipStream, CompressionLevel.Optimal, true)) {
        await memoryStream.CopyToAsync(compressor);
      }

      context.Response.Body = originalBody;
      context.Response.Clear();
      context.Response.ContentType = "application/gzip";
      context.Response.Headers["Content-Disposition"] = "attachment; filename=\"data.geojson.gz\"";

      gzipStream.Seek(0, SeekOrigin.Begin);
      await gzipStream.CopyToAsync(context.Response.Body);
    }
  }
}
