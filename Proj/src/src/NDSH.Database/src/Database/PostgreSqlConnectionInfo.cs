
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Database {

  /// <summary>
  /// The PostgreSQL database connection information.
  /// </summary>
  public sealed class PostgreSqlConnectionInfo : DatabaseConnectionInfo {

    #region Public Properties

    /// <summary>
    /// Gets/Sets the host of the PostgreSQL.
    /// </summary>
    public string Host {
      get; set;
    }

    /// <summary> 
    /// Gets/Sets the database.
    /// </summary>
    public string Database {
      get; set;
    }

    /// <summary>
    /// Gets/Sets the username.
    /// </summary>
    public string Username {
      get; set;
    }

    /// <summary>
    /// Gets/Sets the password.
    /// </summary>
    public string Password {
      get; set;
    }

    /// <summary>
    /// Gets/Sets the schemas of the database.
    /// </summary>
    public List<string> Schemas {
      get; set;
    }

    /// <summary>
    /// Gets/Sets the schema used.
    /// </summary>
    public string UsedSchema {
      get; set;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the PostgreSQL connection string..
    /// </summary>
    /// <returns>A <see cref="string"/> with the PostgreSQL connection string.</returns>
    public override string ToConnectionString() {
      return $"Host={Host};Database={Database};Username={Username};Password={Password}";
    }

    #endregion

  }

}
