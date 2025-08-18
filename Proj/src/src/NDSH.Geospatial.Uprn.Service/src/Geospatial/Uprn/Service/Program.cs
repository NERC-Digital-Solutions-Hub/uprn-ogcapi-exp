using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NDSH.Geospatial.Uprn.Service;
using NDSH.Geospatial.Uprn.Service.Middleware;
using NDSH.Geospatial.Uprn.Service.Security;
using OgcApi.Net;
using OgcApi.Net.OpenApi;
using OgcApi.Net.Options;
using OgcApi.Net.PostGis;
using OgcApi.Net.Schemas;
using System.Text.Json.Nodes;
// using ServiceDefaults;  // Make sure this is included into the project or done as a separate project

var builder = WebApplication.CreateBuilder(args);

// builder.AddServiceDefaults();  // This would add telemetry and other aspire services

builder.Services.AddOgcApiPostGisProvider();
builder.Services.AddSchemasOpenApiExtension();

// If the connection string is configured in the ogcapi.json file
// builder.Services.AddOgcApi("ogcapi.json", TileAccess.TileAccessDelegate, TileAccess.FeatureAccessDelegate);

// If the connection string is determined at runtime
builder.Services.AddSingleton<IConfigureOptions<OgcApiOptions>, ConfigureOgcApiOptions>();

builder.Services.AddSingleton<IOpenApiGenerator, OpenApiGenerator>();

builder.Services.AddControllers().AddOgcApiControllers();

builder.Services.AddCors(c => c.AddPolicy(name: "OgcApi", options => {
  options.AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.UseDeveloperExceptionPage();
}

app.UseSwaggerUI(swaggerOptions => {
  swaggerOptions.RoutePrefix = "api";
  swaggerOptions.SwaggerEndpoint("ogc/swagger.json", "OGC API");
});

app.UseRouting();

app.UseMiddleware<SwaggerJsonModifierMiddleware>("/api/ogc/swagger.json");

app.UseMiddleware<FieldsFilterMiddleware>();

app.MapControllers();

app.UseCors("OgcApi");

app.UseAuthorization();

app.Run();
