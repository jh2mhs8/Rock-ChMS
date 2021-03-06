//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Page Service class
    /// </summary>
    public partial class PageService : Service<Page, PageDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageService"/> class
        /// </summary>
        public PageService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageService"/> class
        /// </summary>
        public PageService(IRepository<Page> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override Page CreateNew()
        {
            return new Page();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<PageDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<PageDto> QueryableDto( IQueryable<Page> items )
        {
            return items.Select( m => new PageDto()
                {
                    Name = m.Name,
                    ParentPageId = m.ParentPageId,
                    Title = m.Title,
                    IsSystem = m.IsSystem,
                    SiteId = m.SiteId,
                    Layout = m.Layout,
                    RequiresEncryption = m.RequiresEncryption,
                    EnableViewState = m.EnableViewState,
                    MenuDisplayDescription = m.MenuDisplayDescription,
                    MenuDisplayIcon = m.MenuDisplayIcon,
                    MenuDisplayChildPages = m.MenuDisplayChildPages,
                    DisplayInNavWhen = m.DisplayInNavWhen,
                    Order = m.Order,
                    OutputCacheDuration = m.OutputCacheDuration,
                    Description = m.Description,
                    IconFileId = m.IconFileId,
                    IncludeAdminFooter = m.IncludeAdminFooter,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( Page item, out string errorMessage )
        {
            errorMessage = string.Empty;
 
            if ( new Service<Page>().Queryable().Any( a => a.ParentPageId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Page.FriendlyTypeName, Page.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Site>().Queryable().Any( a => a.DefaultPageId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Page.FriendlyTypeName, Site.FriendlyTypeName );
                return false;
            }  
            return true;
        }
    }
}
