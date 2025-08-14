
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
  /// The HeadersModel abstract class is used to define a model for headers.
  /// Concrete classes that inherit from this class can be used to specify
  /// the headers of an Uri based request.
  /// (for example an API or web page request).
  /// </summary>
  public abstract class HeadersModel : IndexedPropertiesModel {

  }

}
