//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using Rock;
using Rock.Model;
using Rock.Data;
using Rock.Web.Cache;
using Rock.Web.UI;
using Rock.Web.UI.Controls;
using Site = Rock.Model.Site;
using Rock.Constants;

namespace RockWeb.Blocks.Administration
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SiteDetail : RockBlock, IDetailBlock
    {
        #region Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                string itemId = PageParameter( "siteId" );
                if ( !string.IsNullOrWhiteSpace( itemId ) )
                {
                    ShowDetail( "siteId", int.Parse( itemId ) );
                }
                else
                {
                    pnlDetails.Visible = false;
                }
            }

        }

        #endregion

        #region Edit Events

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnCancel_Click( object sender, EventArgs e )
        {
            NavigateToParentPage();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnSave_Click( object sender, EventArgs e )
        {
            Site site;
            SiteService siteService = new SiteService();
            bool newSite = false;

            int siteId = int.Parse( hfSiteId.Value );

            if ( siteId == 0 )
            {
                newSite = true;
                site = new Rock.Model.Site();
                siteService.Add( site, CurrentPersonId );
            }
            else
            {
                site = siteService.Get( siteId );
                SiteDomainService siteDomainService = new SiteDomainService();
                foreach ( var domain in site.SiteDomains.ToList() )
                {
                    siteDomainService.Delete( domain, CurrentPersonId );
                }

                site.SiteDomains.Clear();
            }

            site.Name = tbSiteName.Text;
            site.Description = tbDescription.Text;
            site.Theme = ddlTheme.Text;
            site.DefaultPageId = int.Parse( ddlDefaultPage.SelectedValue );

            foreach ( string domain in tbSiteDomains.Text.SplitDelimitedValues() )
            {
                SiteDomain sd = new SiteDomain();
                sd.Domain = domain;
                sd.Guid = Guid.NewGuid();
                site.SiteDomains.Add( sd );
            }

            site.FaviconUrl = tbFaviconUrl.Text;
            site.AppleTouchIconUrl = tbAppleTouchIconUrl.Text;
            site.FacebookAppId = tbFacebookAppId.Text;
            site.FacebookAppSecret = tbFacebookAppSecret.Text;

            if ( !site.IsValid )
            {
                // Controls will render the error messages                    
                return;
            }

            RockTransactionScope.WrapTransaction( () =>
            {
                siteService.Save( site, CurrentPersonId );

                if ( newSite )
                {
                    Rock.Security.Authorization.CopyAuthorization( CurrentPage.Site, site, CurrentPersonId );
                }
            } );

            SiteCache.Flush( site.Id );

            NavigateToParentPage();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Loads the drop downs.
        /// </summary>
        private void LoadDropDowns()
        {
            PageService pageService = new PageService();
            List<Rock.Model.Page> allPages = pageService.Queryable().ToList();
            ddlDefaultPage.DataSource = allPages.OrderBy( a => a.PageSortHash );
            ddlDefaultPage.DataBind();

            ddlTheme.Items.Clear();
            DirectoryInfo di = new DirectoryInfo( this.Page.Request.MapPath( this.CurrentTheme ) );
            foreach ( var themeDir in di.Parent.EnumerateDirectories().OrderBy( a => a.Name ) )
            {
                ddlTheme.Items.Add( new ListItem( themeDir.Name, themeDir.Name ) );
            }
        }

        /// <summary>
        /// Shows the edit.
        /// </summary>
        /// <param name="siteId">The site id.</param>
        public void ShowDetail( string itemKey, int itemKeyValue )
        {
            if ( !itemKey.Equals( "siteId" ) )
            {
                return;
            }

            pnlDetails.Visible = true;
            Site site = null;

            if ( !itemKeyValue.Equals( 0 ) )
            {
                site = new SiteService().Get( itemKeyValue );
                lActionTitle.Text = ActionTitle.Edit( Rock.Model.Site.FriendlyTypeName );
            }
            else
            {
                site = new Site { Id = 0 };
                site.SiteDomains = new List<SiteDomain>();
                site.Theme = CurrentPage.Site.Theme;
                lActionTitle.Text = ActionTitle.Add( Rock.Model.Site.FriendlyTypeName );
            }

            LoadDropDowns();

            hfSiteId.Value = site.Id.ToString();

            tbSiteName.Text = site.Name;
            tbDescription.Text = site.Description;
            ddlTheme.SetValue( site.Theme );
            if ( site.DefaultPageId.HasValue )
            {
                ddlDefaultPage.SetValue( site.DefaultPageId );
            }

            tbSiteDomains.Text = string.Join( "\n", site.SiteDomains.Select( dom => dom.Domain ).ToArray() );
            tbFaviconUrl.Text = site.FaviconUrl;
            tbAppleTouchIconUrl.Text = site.AppleTouchIconUrl;
            tbFacebookAppId.Text = site.FacebookAppId;
            tbFacebookAppSecret.Text = site.FacebookAppSecret;

            // render UI based on Authorized and IsSystem
            bool readOnly = false;

            nbEditModeMessage.Text = string.Empty;
            if ( !IsUserAuthorized( "Edit" ) )
            {
                readOnly = true;
                nbEditModeMessage.Text = EditModeMessage.ReadOnlyEditActionNotAllowed( Rock.Model.Site.FriendlyTypeName );
            }

            if ( site.IsSystem )
            {
                readOnly = true;
                nbEditModeMessage.Text = EditModeMessage.ReadOnlySystem( Rock.Model.Site.FriendlyTypeName );
            }

            if ( readOnly )
            {
                lActionTitle.Text = ActionTitle.View( Rock.Model.Site.FriendlyTypeName );
                btnCancel.Text = "Close";
            }

            tbSiteName.ReadOnly = readOnly;
            tbDescription.ReadOnly = readOnly;
            ddlTheme.Enabled = !readOnly;
            ddlDefaultPage.Enabled = !readOnly;
            tbSiteDomains.ReadOnly = readOnly;
            tbFaviconUrl.ReadOnly = readOnly;
            tbAppleTouchIconUrl.ReadOnly = readOnly;
            tbFacebookAppId.ReadOnly = readOnly;
            tbFacebookAppSecret.ReadOnly = readOnly;

            btnSave.Visible = !readOnly;
        }

        #endregion
    }
}