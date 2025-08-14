
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Database {

  /// <summary>
  /// Represents the type of database.
  /// </summary>
  public enum DatabaseType {

    /// <summary>
    /// No database type specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// The database type is PostgreSQL.
    /// </summary>
    PostgreSQL = 1,

    /// <summary>
    /// The database type is SQLite.
    /// </summary>
    SQLite = 2,

    /// <summary>
    /// The database type is SQL Server.
    /// </summary>
    SqlServer = 3,

    /// <summary>
    /// The database type is Oracle.
    /// </summary>
    Oracle = 4,

    /// <summary>
    /// The database type is MongoDB.
    /// </summary>
    MongoDB = 5,

    /// <summary>
    /// The database type is RavenDB.
    /// </summary>
    RavenDB = 6,

  }

}
