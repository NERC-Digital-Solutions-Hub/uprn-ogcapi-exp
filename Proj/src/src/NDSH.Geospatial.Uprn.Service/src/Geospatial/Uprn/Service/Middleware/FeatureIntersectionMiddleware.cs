using OgcApi.Net.Controllers;

namespace NDSH.Geospatial.Uprn.Service.Middleware {
  public class FeatureIntersectionMiddleware {

    private readonly RequestDelegate _next;
    private readonly CollectionsController _controller;

    public FeatureIntersectionMiddleware(RequestDelegate next, CollectionsController controller) {
      _next = next;
      _controller = controller;
    }

    public async Task InvokeAsync(HttpContext context, CollectionsController collectionsController) {

      if (!context.Request.Path.Value.Contains("/items")) {
        await _next(context);
        return;
      }

      if (!context.Request.Query.ContainsKey("sourceSelector") && !context.Request.Query.ContainsKey("selectorIds")) {
        await _next(context);
        return;
      }

      var selectorSource = context.Request.Query["selectorSource"].ToString();
      var selectorIds = context.Request.Query["selectorIds"].ToString().Split(',').Select(int.Parse).ToList();

      var selectorResult = await collectionsController.GetItems(selectorSource)  // TODO: populate from context.Request.Query
    }
  }
}
