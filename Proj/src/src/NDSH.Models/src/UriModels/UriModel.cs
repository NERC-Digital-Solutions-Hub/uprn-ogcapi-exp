
#region Imported Namespaces

using NDSH.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.UriModels {

  /// <summary>
  /// The UriModel is used to define an URI based request that has a set of parameters defined in the
  /// <typeparamref name="TQueryParameters">
  /// instance that inherits from the <see cref="QueryParametersModel"/>
  /// </typeparamref> and
  /// <typeparamref name="THeaders">
  /// instance that inherits from the <see cref="HeadersModel"/>
  /// </typeparamref>
  /// </summary>
  public abstract class UriModel<TQueryParameters, THeaders> : IndexedPropertiesModel
    where TQueryParameters : QueryParametersModel
    where THeaders : HeadersModel {

    /// <summary>
    /// Gets or sets the scheme of the URI.
    /// </summary>
    /// <remarks>The default value is: "http"</remarks>
    /// <example>Values could be "http", "https", "ftp", etc.</example>
    public string Scheme { get; set; } = "http";

    /// <summary>
    /// Gets or sets the host of the URI.
    /// </summary>
    /// <remarks>The default value is: "localhost"</remarks>
    /// <example>"api.example.com"</example>
    public string Host { get; set; } = "localhost";

    /// <summary>
    /// Gets or sets the port number of the URI.
    /// </summary>
    /// <remarks>Default value is 80.</remarks>
    /// <example>(e.g., 80 for HTTP).</example>
    public int Port { get; set; } = 80;

    /// <summary>
    /// Gets or sets the relative endpoint path.
    /// </summary>
    /// <example>(e.g., "/products")</example>
    public string? EndpointPath {
      get; set;
    }

    /// <summary>
    /// Gets or sets the <typeparamref name="TQueryParameters">instance inheriting from
    /// <see cref="QueryParametersModel"/> providing the query parameters.</typeparamref>
    /// </summary>
    public TQueryParameters? QueryParameters {
      get; set;
    }

    /// <summary>
    /// Gets/Sets the <typeparamref name="THeaders">instance inheriting from
    /// <see cref="HeadersModel"/> providing the headers.</typeparamref>
    /// </summary>
    public THeaders? Headers {
      get; set;
    }

    ///// <summary>
    ///// Gets the query parameters to include in the request URI.
    ///// </summary>
    //public IDictionary<string, string> QueryParameters { get; } = new Dictionary<string, string>();

    ///// <summary>
    ///// Gets the headers to include in the request.
    ///// </summary>
    //public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

    ///// <summary>
    ///// Gets the full URI for the request.
    ///// </summary>
    //public Uri RequestUri {
    //  get {
    //    // Create the URI using the properties
    //    var builder = new UriBuilder {
    //      Scheme = Scheme,
    //      Host = Host,
    //      Port = Port,
    //      Path = EndpointPath,
    //      Query = BuildQueryString(QueryParameters)
    //    };

    //    return builder.Uri;
    //  }
    //}

    ///// <summary>
    ///// Builds a query string from a dictionary of query parameters.
    ///// </summary>
    //private string BuildQueryString(IDictionary<string, string> parameters) {
    //  var queryString = new UriBuilder("", "").Query;

    //  foreach (var parameter in parameters) {
    //    queryString += $"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}&";
    //  }

    //  return queryString.TrimEnd('&');
    //}

  }

}
