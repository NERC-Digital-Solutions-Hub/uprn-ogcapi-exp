
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Database {

  /// <summary>
  /// The database connection information.
  /// </summary>
  public abstract class DatabaseConnectionInfo {

    /// <summary>
    /// Gets/Sets the name of the database connection information.
    /// </summary>
    /// <remarks>
    /// The name is used to distinguish between more than
    /// one connection strings used by the application.
    /// </remarks>
    public string Name {
      get; set;
    }

    /// <summary>
    /// Provides the database connection string associated with the database connection information.
    /// </summary>
    /// <returns>A <see cref="string"/> with the database connection string.</returns>
    public abstract string ToConnectionString();

  }

}
