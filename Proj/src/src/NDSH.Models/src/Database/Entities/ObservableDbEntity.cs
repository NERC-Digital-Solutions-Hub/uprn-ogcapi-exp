
#region Header
// ---------------------------------------------------------------------------------------------------------------------
// Member of         : NDSH.Geospatial.Metadata.ISO19115.Ed2003.csproj
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

#endregion

namespace NDSH.Database.Entities {

  /// <summary>
  /// Represents the base database entity that notifies observers of property changes.
  /// </summary>
  public abstract class ObservableDbEntity : ObservableModel, IDbId {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ObservableDbEntity"/>.
    /// </summary>
    public ObservableDbEntity() {

    }

    /// <summary>
    /// Initializes the <see cref="ObservableDbEntity"/> using a predefined id.
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
    public ObservableDbEntity(int dbId) {
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
      set => SetProperty(ref _dbid, value);
    }

    #endregion

  }

}
