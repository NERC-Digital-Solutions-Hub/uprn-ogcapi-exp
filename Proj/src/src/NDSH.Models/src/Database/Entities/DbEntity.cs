
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Models.csproj
// Created           : 12/02/2022, @gisvlasta
// GitHub Repository : https://github.com/NERC-Digital-Solutions-Hub/ndsh
// License           : MIT Licence
// Copyright         : 
//
// Comments          : 
// ---------------------------------------------------------------------------------------------------------------------
#endregion

#region Imported Namespaces

using NDSH.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace NDSH.Database.Entities {

  /// <summary>
  /// Serves as the base class for database entities, providing an integer identifier
  /// <see cref="DbId"/> and optional constructor-based ID assignment.
  /// Inherit from this class to create custom entities that integrate
  /// with frameworks requiring a unique integer key.
  /// </summary>
  public abstract class DbEntity : Model, IDbId, IHashCode {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the DbEntity.
    /// </summary>
    public DbEntity() {

    }

    /// <summary>
    /// Initializes the DbEntity using a predefined id.
    /// </summary>
    /// <param name="dbId">The database entity id.</param>
    /// <remarks>
    /// <list type="bullet">
    ///   <item>
    ///     Use this constructor in frameworks that require setting the database entity during initialization.
    ///   </item>
    ///   <item>
    ///     If you want Entity Framework to call it automatically, you’ll need additional
    ///     mapping configurations in EF Core (using <c>HasConstructorBinding</c>, for example).
    ///   </item>
    /// </list>
    /// </remarks>
    public DbEntity(int dbId) {
      DbId = dbId;
    }

    #endregion

    #region IDbId Interface

    private int _dbid = default;

    /// <summary>
    /// Gets/Sets the DbId.
    /// </summary>
    public virtual int DbId {
      get => _dbid;
      set => _dbid = value;
    }

    #endregion

    #region IHashCode Interface

    private int? _hashCode;

    /// <summary>
    /// Gets/Sets the HashCode.
    /// </summary>
    public virtual int? HashCode {
      get => _hashCode;
      set => _hashCode = value;
    }

    #endregion

  }

}
