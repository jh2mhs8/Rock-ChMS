﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Runtime.Caching;

using Rock.Model;
using Rock.Security;

namespace Rock.Web.Cache
{
    /// <summary>
    /// Information about a block that is required by the rendering engine.
    /// This information will be cached by the engine
    /// </summary>
    [Serializable]
    public class BlockCache : CachedModel<Block>
    {
        #region Constructors

        private BlockCache()
        {
        }

        private BlockCache( Block block, int? siteId )
        {
            CopyFromModel( block );
            SiteId = siteId;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the page id.
        /// </summary>
        /// <value>
        /// The page id.
        /// </value>
        public int? PageId { get; set; }

        /// <summary>
        /// Gets or sets the site id.
        /// </summary>
        /// <value>
        /// The site id.
        /// </value>
        public int? SiteId { get; set; }

        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        /// <value>
        /// The layout.
        /// </value>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the block type id.
        /// </summary>
        /// <value>
        /// The block type id.
        /// </value>
        public int BlockTypeId { get; set; }

        /// <summary>
        /// Gets or sets the zone.
        /// </summary>
        /// <value>
        /// The zone.
        /// </value>
        public string Zone { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the duration of the output cache.
        /// </summary>
        /// <value>
        /// The duration of the output cache.
        /// </value>
        public int OutputCacheDuration { get; set; }

        /// <summary>
        /// Gets the page.
        /// </summary>
        public PageCache Page
        {
            get
            {
                if ( PageId.HasValue )
                    return PageCache.Read( PageId.Value );
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets the <see cref="Site"/> object for the block.
        /// </summary>
        public SiteCache Site
        {
            get
            {
                if ( SiteId != null && SiteId.Value != 0 )
                {
                    return SiteCache.Read( SiteId.Value );
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the block type
        /// </summary>
        public BlockTypeCache BlockType
        {
            get
            {
                return BlockTypeCache.Read( BlockTypeId );
            }
        }

        /// <summary>
        /// Gets the parent authority.
        /// </summary>
        /// <value>
        /// The parent authority.
        /// </value>
        public override ISecured ParentAuthority
        {
            get
            {
                if ( this.BlockLocation == Model.BlockLocation.Page )
                {
                    return this.Page;
                }
                else
                {
                    return this.Site;
                }
            }
        }

        /// <summary>
        /// Gets the block location.
        /// </summary>
        /// <value>
        /// The block location.
        /// </value>
        public virtual BlockLocation BlockLocation
        {
            get { return this.PageId.HasValue ? BlockLocation.Page : BlockLocation.Layout; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Copies from model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyFromModel( Data.IEntity model )
        {
            base.CopyFromModel( model );

            if ( model is Block )
            {
                var block = (Block)model;
                this.IsSystem = block.IsSystem;
                this.PageId = block.PageId;
                this.Layout = block.Layout;
                this.BlockTypeId = block.BlockTypeId;
                this.Zone = block.Zone;
                this.Order = block.Order;
                this.Name = block.Name;

                this.OutputCacheDuration = block.OutputCacheDuration;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }

        #endregion

        #region Static Methods

        private static string CacheKey( int id )
        {
            return string.Format( "Rock:Block:{0}", id );
        }

        /// <summary>
        /// Returns Block object from cache.  If block does not already exist in cache, it
        /// will be read and added to cache
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="siteId">The site id.</param>
        /// <returns></returns>
        public static BlockCache Read( int id, int? siteId )
        {
            string cacheKey = BlockCache.CacheKey( id );

            ObjectCache cache = MemoryCache.Default;
            BlockCache block = cache[cacheKey] as BlockCache;

            if ( block != null )
            {
                return block;
            }
            else
            {
                var blockService = new BlockService();
                var blockModel = blockService.Get( id );
                if ( blockModel != null )
                {
                    blockModel.LoadAttributes();
                    block = new BlockCache( blockModel, siteId );

                    var cachePolicy = new CacheItemPolicy();
                    cache.Set( cacheKey, block, cachePolicy );
                    cache.Set( block.Guid.ToString(), block.Id, cachePolicy );

                    return block;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Reads the specified GUID.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <param name="siteId">The site id.</param>
        /// <returns></returns>
        public static BlockCache Read( Guid guid, int? siteId )
        {
            ObjectCache cache = MemoryCache.Default;
            object cacheObj = cache[guid.ToString()];

            if ( cacheObj != null )
            {
                return Read( (int)cacheObj, siteId );
            }
            else
            {
                var blockService = new BlockService();
                var blockModel = blockService.Get( guid );
                if ( blockModel != null )
                {
                    blockModel.LoadAttributes();
                    var block = new BlockCache( blockModel, siteId );

                    var cachePolicy = new CacheItemPolicy();
                    cache.Set( BlockCache.CacheKey( block.Id ), block, cachePolicy );
                    cache.Set( block.Guid.ToString(), block.Id, cachePolicy );

                    return block;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Adds Block model to cache, and returns cached object
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        /// <param name="siteId">The site id.</param>
        /// <returns></returns>
        public static BlockCache Read( Block blockModel, int? siteId )
        {
            string cacheKey = BlockCache.CacheKey( blockModel.Id );

            ObjectCache cache = MemoryCache.Default;
            BlockCache block = cache[cacheKey] as BlockCache;

            if ( block != null )
            {
                return block;
            }
            else
            {
                block = new BlockCache( blockModel, siteId );

                var cachePolicy = new CacheItemPolicy();
                cache.Set( cacheKey, block, cachePolicy );
                cache.Set( block.Guid.ToString(), block.Id, cachePolicy );

                return block;
            }
        }

        /// <summary>
        /// Removes block from cache
        /// </summary>
        /// <param name="id"></param>
        public static void Flush( int id )
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove( BlockCache.CacheKey( id ) );
        }

        #endregion

    }

}