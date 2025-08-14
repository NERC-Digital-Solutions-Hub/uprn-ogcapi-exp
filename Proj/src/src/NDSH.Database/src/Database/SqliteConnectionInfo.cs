
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Database {

  /// <summary>
  /// The SQLite database connection information.
  /// </summary>
  public class SqliteConnectionInfo : DatabaseConnectionInfo {

    #region Public Properties

    private string _filePath;

    /// <summary>
    /// 
    /// </summary>
    public string FilePath {
      get {
        return _filePath;
      }
      set {
        if (_filePath != value) {
          _filePath = value;
        }
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the SQLite connection string.
    /// </summary>
    /// <returns>A <see cref="string"/> with the SQLite connection string.</returns>
    public override string ToConnectionString() {
      return $"Data Source={FilePath}";
    }

    #endregion

  }

}
