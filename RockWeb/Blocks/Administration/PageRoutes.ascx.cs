﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using Rock;
using Rock.Model;
using Rock.Constants;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Blocks.Administration
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PageRoutes : RockBlock
    {
        #region Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            if ( CurrentPage.IsAuthorized( "Administrate", CurrentPerson ) )
            {
                gPageRoutes.DataKeyNames = new string[] { "id" };
                gPageRoutes.Actions.IsAddEnabled = true;
                gPageRoutes.Actions.AddClick += gPageRoutes_Add;
                gPageRoutes.GridRebind += gPageRoutes_GridRebind;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            nbMessage.Visible = false;

            if ( CurrentPage.IsAuthorized( "Administrate", CurrentPerson ) )
            {
                if ( !Page.IsPostBack )
                {
                    BindGrid();
                    LoadDropDowns();
                }
            }
            else
            {
                gPageRoutes.Visible = false;
                nbMessage.Text = WarningMessage.NotAuthorizedToEdit( PageRoute.FriendlyTypeName );
                nbMessage.Visible = true;
            }

            base.OnLoad( e );
        }
        #endregion

        #region Grid Events

        /// <summary>
        /// Handles the Add event of the gPageRoutes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void gPageRoutes_Add( object sender, EventArgs e )
        {
            ShowEdit( 0 );
        }

        /// <summary>
        /// Handles the Edit event of the gPageRoutes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowEventArgs" /> instance containing the event data.</param>
        protected void gPageRoutes_Edit( object sender, RowEventArgs e )
        {
            ShowEdit( (int)gPageRoutes.DataKeys[e.RowIndex]["id"] );
        }

        /// <summary>
        /// Handles the Delete event of the gPageRoutes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowEventArgs" /> instance containing the event data.</param>
        protected void gPageRoutes_Delete( object sender, RowEventArgs e )
        {
            PageRouteService pageRouteService = new PageRouteService();
            PageRoute pageRoute = pageRouteService.Get( (int)gPageRoutes.DataKeys[e.RowIndex]["id"] );
            if ( CurrentBlock != null )
            {
                pageRouteService.Delete( pageRoute, CurrentPersonId );
                pageRouteService.Save( pageRoute, CurrentPersonId );
            }

            RemovePageRoute( pageRoute );

            BindGrid();
        }

        /// <summary>
        /// Handles the GridRebind event of the gPageRoutes control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void gPageRoutes_GridRebind( object sender, EventArgs e )
        {
            BindGrid();
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
            pnlDetails.Visible = false;
            pnlList.Visible = true;
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnSave_Click( object sender, EventArgs e )
        {
            PageRoute pageRoute;
            PageRouteService pageRouteService = new PageRouteService();

            int pageRouteId = int.Parse( hfPageRouteId.Value );

            if ( pageRouteId == 0 )
            {
                pageRoute = new PageRoute();
                pageRouteService.Add( pageRoute, CurrentPersonId );
            }
            else
            {
                pageRoute = pageRouteService.Get( pageRouteId );
            }

            pageRoute.Route = tbRoute.Text.Trim();
            int selectedPageId = int.Parse( ddlPageName.SelectedValue );
            pageRoute.PageId = selectedPageId;

            // check for duplicates
            if ( pageRouteService.Queryable().Count( a => a.Route.Equals( pageRoute.Route, StringComparison.OrdinalIgnoreCase ) && !a.Id.Equals( pageRoute.Id ) ) > 0 )
            {
                nbMessage.Text = WarningMessage.DuplicateFoundMessage( "route", Rock.Model.Page.FriendlyTypeName );
                nbMessage.Visible = true;
                return;
            }

            if ( !pageRoute.IsValid )
            {
                // Controls will render the error messages                    
                return;
            }

            pageRouteService.Save( pageRoute, CurrentPersonId );

            RemovePageRoute( pageRoute );

            // new or updated route
            RouteTable.Routes.AddPageRoute( pageRoute );

            BindGrid();
            pnlDetails.Visible = false;
            pnlList.Visible = true;
        }

        /// <summary>
        /// Removes the page route.
        /// </summary>
        /// <param name="pageRoute">The page route.</param>
        private static void RemovePageRoute( PageRoute pageRoute )
        {
            var existingRoute = RouteTable.Routes.OfType<Route>().FirstOrDefault( a => a.RouteId() == pageRoute.Id );
            if ( existingRoute != null )
            {
                RouteTable.Routes.Remove( existingRoute );
            }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Binds the grid.
        /// </summary>
        private void BindGrid()
        {
            PageRouteService pageRouteService = new PageRouteService();
            SortProperty sortProperty = gPageRoutes.SortProperty;

            if ( sortProperty != null )
            {
                gPageRoutes.DataSource = pageRouteService.Queryable().Sort( sortProperty ).ToList();
            }
            else
            {
                gPageRoutes.DataSource = pageRouteService.Queryable().OrderBy( p => p.Route ).ToList();
            }

            gPageRoutes.DataBind();
        }

        /// <summary>
        /// Loads the drop downs.
        /// </summary>
        private void LoadDropDowns()
        {
            PageService pageService = new PageService();
            List<Rock.Model.Page> allPages = pageService.Queryable().ToList();
            ddlPageName.DataSource = allPages.OrderBy( a => a.PageSortHash );
            ddlPageName.DataBind();
        }

        /// <summary>
        /// Shows the edit.
        /// </summary>
        /// <param name="pageRouteId">The page route id.</param>
        protected void ShowEdit( int pageRouteId )
        {
            pnlList.Visible = false;
            pnlDetails.Visible = true;

            PageRouteService pageRouteService = new PageRouteService();
            PageRoute pageRoute = pageRouteService.Get( pageRouteId );
            bool readOnly;

            if ( pageRoute != null )
            {
                hfPageRouteId.Value = pageRoute.Id.ToString();
                ddlPageName.SetValue( pageRoute.PageId );
                tbRoute.Text = pageRoute.Route;
                readOnly = pageRoute.IsSystem;

                if ( pageRoute.IsSystem )
                {
                    lActionTitle.Text = ActionTitle.View( PageRoute.FriendlyTypeName );
                    btnCancel.Text = "Close";
                }
                else
                {
                    lActionTitle.Text = ActionTitle.Edit( PageRoute.FriendlyTypeName );
                    btnCancel.Text = "Cancel";
                }
            }
            else
            {
                lActionTitle.Text = ActionTitle.Add( PageRoute.FriendlyTypeName );
                hfPageRouteId.Value = 0.ToString();
                ddlPageName.SetValue( string.Empty );
                tbRoute.Text = string.Empty;
                readOnly = false;
            }

            iconIsSystem.Visible = readOnly;
            ddlPageName.Enabled = !readOnly;
            tbRoute.ReadOnly = readOnly;
            btnSave.Visible = !readOnly;
        }

        #endregion
    }
}