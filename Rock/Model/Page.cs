//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Page POCO Entity.
    /// </summary>
    [Table( "Page" )]
    [DataContract( IsReference = true )]
    public partial class Page : Model<Page>, IOrdered
    {

        #region Entity Properties

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [Required]
        [MaxLength( 100 )]
        [TrackChanges]
        [DataMember( IsRequired = true )]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Parent Page Id.
        /// </summary>
        /// <value>
        /// Parent Page Id.
        /// </value>
        [DataMember]
        public int? ParentPageId { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>
        /// Title.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the IsSystem.
        /// </summary>
        /// <value>
        /// IsSystem.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the Site Id.
        /// </summary>
        /// <value>
        /// Site Id.
        /// </value>
        [DataMember]
        public int? SiteId { get; set; }

        /// <summary>
        /// Gets or sets the Layout.
        /// </summary>
        /// <value>
        /// Layout.
        /// </value>
        [MaxLength( 100 )]
        [DataMember]
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the Requires Encryption.
        /// </summary>
        /// <value>
        /// Requires Encryption.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool RequiresEncryption { get; set; }

        /// <summary>
        /// Gets or sets the Enable View State.
        /// </summary>
        /// <value>
        /// Enable View State.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool EnableViewState
        {
            get { return _enableViewState; }
            set { _enableViewState = value; }
        }
        private bool _enableViewState = true;

        /// <summary>
        /// Gets or sets the Menu Display Description.
        /// </summary>
        /// <value>
        /// Menu Display Description.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool MenuDisplayDescription { get; set; }

        /// <summary>
        /// Gets or sets the Menu Display Icon.
        /// </summary>
        /// <value>
        /// Menu Display Icon.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool MenuDisplayIcon { get; set; }

        /// <summary>
        /// Gets or sets the Menu Display Child Pages.
        /// </summary>
        /// <value>
        /// Menu Display Child Pages.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool MenuDisplayChildPages { get; set; }

        /// <summary>
        /// Gets or sets the Display In Nav When.
        /// </summary>
        /// <value>
        /// Determines when to display in a navigation 
        /// 0 = When Security Allows
        /// 1 = Always
        /// 3 = Never   
        /// 
        /// Enum[DisplayInNavWhen].
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public DisplayInNavWhen DisplayInNavWhen { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class.
        /// </summary>
        /// <value>
        /// The icon CSS class.
        /// </value>
        [DataMember]
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets the Order.
        /// </summary>
        /// <value>
        /// Order.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the Output Cache Duration.
        /// </summary>
        /// <value>
        /// Output Cache Duration.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public int OutputCacheDuration { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// Description.
        /// </value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Icon File ID.
        /// </summary>
        /// <value>
        /// Icon Url.
        /// </value>
        [DataMember]
        public int? IconFileId { get; set; }

        /// <summary>
        /// Gets or sets the Include Admin Footer.
        /// </summary>
        /// <value>
        /// Include Admin Footer.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool IncludeAdminFooter
        {
            get { return _includeAdminFooter; }
            set { _includeAdminFooter = value; }
        }
        private bool _includeAdminFooter = true;

        #endregion

        #region Virtual Properties

        /// <summary>
        /// Gets or sets the Parent Page.
        /// </summary>
        /// <value>
        /// A <see cref="Page"/> object.
        /// </value>
        [DataMember]
        public virtual Page ParentPage { get; set; }

        /// <summary>
        /// Gets or sets the Site.
        /// </summary>
        /// <value>
        /// A <see cref="Site"/> object.
        /// </value>
        [DataMember]
        public virtual Site Site { get; set; }

        /// <summary>
        /// Gets or sets the icon file.
        /// </summary>
        /// <value>
        /// The icon file.
        /// </value>
        [DataMember]
        public virtual BinaryFile IconFile { get; set; }

        /// <summary>
        /// Gets or sets the Blocks.
        /// </summary>
        /// <value>
        /// Collection of Blocks.
        /// </value>
        [DataMember]
        public virtual ICollection<Block> Blocks
        {
            get { return _blocks ?? ( _blocks = new Collection<Block>() ); }
            set { _blocks = value; }
        }
        private ICollection<Block> _blocks;

        /// <summary>
        /// Gets or sets the Pages.
        /// </summary>
        /// <value>
        /// Collection of Pages.
        /// </value>
        [DataMember]
        public virtual ICollection<Page> Pages
        {
            get { return _pages ?? ( _pages = new Collection<Page>() ); }
            set { _pages = value; }
        }
        private ICollection<Page> _pages;

        /// <summary>
        /// Gets or sets the Page Routes.
        /// </summary>
        /// <value>
        /// Collection of Page Routes.
        /// </value>
        [DataMember]
        public virtual ICollection<PageRoute> PageRoutes
        {
            get { return _pageRoutes ?? ( _pageRoutes = new Collection<PageRoute>() ); }
            set { _pageRoutes = value; }
        }
        private ICollection<PageRoute> _pageRoutes;

        /// <summary>
        /// Gets or sets the Page Contexts.
        /// </summary>
        /// <value>
        /// Collection of Page Contexts.
        /// </value>
        [DataMember]
        public virtual ICollection<PageContext> PageContexts
        {
            get { return _pageContexts ?? ( _pageContexts = new Collection<PageContext>() ); }
            set { _pageContexts = value; }
        }
        private ICollection<PageContext> _pageContexts;

        /// <summary>
        /// Gets the parent authority.
        /// </summary>
        /// <value>
        /// The parent authority.
        /// </value>
        public override Security.ISecured ParentAuthority
        {
            get
            {
                return this.Site;
            }
        }

        /// <summary>
        /// Pages the sort hash.
        /// </summary>
        /// <returns></returns>
        public virtual string PageSortHash
        {
            get
            {
                string result = Title.PadRight( 100, ' ' );
                var _parentPage = ParentPage;
                while ( _parentPage != null )
                {
                    result = _parentPage.Title.PadRight( 100, ' ' ) + result;
                    _parentPage = _parentPage.ParentPage;
                }

                return result;
            }
        }

        /// <summary>
        /// Pages the depth.
        /// </summary>
        /// <returns></returns>
        public virtual int PageDepth
        {
            get
            {
                int result = 0;
                var _parentPage = ParentPage;
                while ( _parentPage != null )
                {
                    result++;
                    _parentPage = _parentPage.ParentPage;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the drop down list text.
        /// </summary>
        /// <value>
        /// The drop down list text.
        /// </value>
        public virtual string DropDownListText
        {
            get
            {
                return new string( '-', PageDepth ) + Title;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
    #region Entity Configuration

    /// <summary>
    /// Page Configuration class.
    /// </summary>
    public partial class PageConfiguration : EntityTypeConfiguration<Page>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageConfiguration"/> class.
        /// </summary>
        public PageConfiguration()
        {
            this.HasOptional( p => p.ParentPage ).WithMany( p => p.Pages ).HasForeignKey( p => p.ParentPageId ).WillCascadeOnDelete( false );
            this.HasOptional( p => p.Site ).WithMany( p => p.Pages ).HasForeignKey( p => p.SiteId ).WillCascadeOnDelete( false );
            this.HasOptional( p => p.IconFile ).WithMany().HasForeignKey( p => p.IconFileId ).WillCascadeOnDelete( false );
        }
    }

    #endregion

    #region Enumerations

    /// <summary>
    /// How should page be displayed in a page navigation block
    /// </summary>
    public enum DisplayInNavWhen
    {
        /// <summary>
        /// Display this page in navigation controls when allowed by security
        /// </summary>
        WhenAllowed = 0,

        /// <summary>
        /// Always display this page in navigation controls, regardless of security
        /// </summary>
        Always = 1,

        /// <summary>
        /// Never display this page in navigation controls
        /// </summary>
        Never = 2
    }

    #endregion
}
