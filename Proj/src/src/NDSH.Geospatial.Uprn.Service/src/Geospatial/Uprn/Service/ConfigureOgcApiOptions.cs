using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NDSH.Geospatial.Uprn.Service.Security;
using OgcApi.Net.Options;
using OgcApi.Net.Options.Converters;
using OgcApi.Net.Options.Features;
using OgcApi.Net.Schemas.Converters;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace NDSH.Geospatial.Uprn.Service;

/// <summary>
/// Configures the OGC API options from a JSON file specified in the configuration.
/// </summary>
/// <param name="configuration">The configuration to read values from.</param>
public class ConfigureOgcApiOptions(IConfiguration configuration) : IConfigureOptions<OgcApiOptions> {
  private static JsonSerializerOptions _ogcJsonSerializerOptions;

  public void Configure(OgcApiOptions options) {
    _ogcJsonSerializerOptions ??= new JsonSerializerOptions {
      Converters =
        {
                new FeaturesSourceOptionsConverter(),
                new TilesSourceOptionsConverter(),
                new SchemaCollectionOptionsConverter()
            }
    };

    var fileName = configuration.GetValue<string>("OgcSettingsFileName");

    var ogcApiOptions = JsonSerializer.Deserialize<OgcApiOptions>(File.ReadAllBytes(fileName), _ogcJsonSerializerOptions);

    if (ogcApiOptions == null) {
      return;
    }

    var postgresConnectionString = configuration.GetConnectionString("PostgresConnectionString");

    foreach (var item in ogcApiOptions.Collections.Items.Where(x => x.Features != null)) {
      if (item.Features.Storage is not SqlFeaturesSourceOptions sourceOptions) {
        continue;
      }

      else if (sourceOptions.Type == "PostGis") {
        sourceOptions.ConnectionString = postgresConnectionString;
      }
    }

    foreach (var item in ogcApiOptions.Collections.Items.Where(x => x.Tiles != null)) {
      item.Tiles.Storage.TileAccessDelegate = TileAccess.TilesAccessDelegate;
      item.Tiles.Storage.FeatureAccessDelegate = TileAccess.FeatureAccessDelegate;
    }

    options.Collections = ogcApiOptions.Collections;
    options.Conformance = ogcApiOptions.Conformance;
    options.LandingPage = ogcApiOptions.LandingPage;
    options.UseApiKeyAuthorization = ogcApiOptions.UseApiKeyAuthorization;
  }
}
