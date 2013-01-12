﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Rock;
using Rock.Constants;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI;
using Rock.Web.UI.Controls;
using Attribute = Rock.Model.Attribute;

namespace RockWeb.Blocks.Administration
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MarketingCampaignAdTypeDetail : RockBlock, IDetailBlock
    {
        #region Child Grid States

        /// <summary>
        /// Gets or sets the state of the attributes.
        /// </summary>
        /// <value>
        /// The state of the attributes.
        /// </value>
        private ViewStateList<Attribute> AttributesState
        {
            get
            {
                return ViewState["AttributesState"] as ViewStateList<Attribute>;
            }

            set
            {
                ViewState["AttributesState"] = value;
            }
        }

        #endregion

        #region Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            gMarketingCampaignAdAttributeTypes.DataKeyNames = new string[] { "Guid" };
            gMarketingCampaignAdAttributeTypes.Actions.IsAddEnabled = true;
            gMarketingCampaignAdAttributeTypes.Actions.AddClick += gMarketingCampaignAdAttributeType_Add;
            gMarketingCampaignAdAttributeTypes.GridRebind += gMarketingCampaignAdAttributeType_GridRebind;
            gMarketingCampaignAdAttributeTypes.EmptyDataText = Server.HtmlEncode( None.Text );
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                string itemId = PageParameter( "marketingCampaignAdTypeId" );
                if ( !string.IsNullOrWhiteSpace( itemId ) )
                {
                    ShowDetail( "marketingCampaignAdTypeId", int.Parse( itemId ) );
                }
                else
                {
                    pnlDetails.Visible = false;
                }
            }
        }

        #endregion

        #region AttributeTypes Grid and Picker

        /// <summary>
        /// Handles the Add event of the gMarketingCampaignAdAttributeType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void gMarketingCampaignAdAttributeType_Add( object sender, EventArgs e )
        {
            gMarketingCampaignAdAttributeType_ShowEdit( Guid.Empty );
        }

        /// <summary>
        /// Handles the Edit event of the gMarketingCampaignAdAttributeType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowEventArgs" /> instance containing the event data.</param>
        protected void gMarketingCampaignAdAttributeType_Edit( object sender, RowEventArgs e )
        {
            Guid attributeGuid = (Guid)e.RowKeyValue;
            gMarketingCampaignAdAttributeType_ShowEdit( attributeGuid );
        }

        /// <summary>
        /// Gs the marketing campaign ad attribute type_ show edit.
        /// </summary>
        /// <param name="attributeId">The attribute id.</param>
        protected void gMarketingCampaignAdAttributeType_ShowEdit( Guid attributeGuid )
        {
            pnlDetails.Visible = false;
            pnlAdTypeAttribute.Visible = true;

            if ( attributeGuid != Guid.Empty )
            {
                Attribute attribute = AttributesState.First( a => a.Guid.Equals( attributeGuid ) );
                lAttributeActionTitle.Text = ActionTitle.Edit( "attribute for ad type " + tbName.Text );
                hfAttributeGuid.Value = attribute.Guid.ToString();
                tbAttributeKey.Text = attribute.Key;
                tbAttributeName.Text = attribute.Name;
                tbAttributeCategory.Text = attribute.Category;
                tbAttributeDescription.Text = attribute.Description;
                tbAttributeDefaultValue.Text = attribute.DefaultValue;
                ddlAttributeFieldType.SelectedValue = attribute.FieldTypeId.ToString();
                cbAttributeMultiValue.Checked = attribute.IsMultiValue;
                cbAttributeRequired.Checked = attribute.IsRequired;
            }
            else
            {
                hfAttributeGuid.Value = Guid.NewGuid().ToString();
                lAttributeActionTitle.Text = ActionTitle.Add( "attribute for ad type " + tbName.Text );
                tbAttributeKey.Text = string.Empty;
                tbAttributeName.Text = string.Empty;
                tbAttributeCategory.Text = string.Empty;
                tbAttributeDescription.Text = string.Empty;
                tbAttributeDefaultValue.Text = string.Empty;
                cbAttributeMultiValue.Checked = false;
                cbAttributeRequired.Checked = false;
            }
        }

        /// <summary>
        /// Handles the Delete event of the gMarketingCampaignAdAttributeType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowEventArgs" /> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected void gMarketingCampaignAdAttributeType_Delete( object sender, RowEventArgs e )
        {
            Guid attributeGuid = (Guid)e.RowKeyValue;
            AttributesState.RemoveEntity( attributeGuid );

            BindMarketingCampaignAdAttributeTypeGrid();
        }

        /// <summary>
        /// Handles the GridRebind event of the gMarketingCampaignAdAttributeType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void gMarketingCampaignAdAttributeType_GridRebind( object sender, EventArgs e )
        {
            BindMarketingCampaignAdAttributeTypeGrid();
        }

        /// <summary>
        /// Handles the Click event of the btnSaveAttribute control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnSaveAttribute_Click( object sender, EventArgs e )
        {
            Attribute attribute = new Attribute();
            attribute.Guid = new Guid( hfAttributeGuid.Value );
            attribute.Key = tbAttributeKey.Text;
            attribute.Name = tbAttributeName.Text;
            attribute.Category = tbAttributeCategory.Text;
            attribute.Description = tbAttributeDescription.Text;
            attribute.DefaultValue = tbAttributeDefaultValue.Text;
            attribute.FieldTypeId = int.Parse( ddlAttributeFieldType.SelectedValue );
            attribute.IsMultiValue = cbAttributeMultiValue.Checked;
            attribute.IsRequired = cbAttributeRequired.Checked;

            // Controls will show warnings
            if ( !attribute.IsValid )
            {
                return;
            }

            AttributesState.RemoveEntity( attribute.Guid );
            AttributesState.Add( attribute );

            pnlDetails.Visible = true;
            pnlAdTypeAttribute.Visible = false;

            BindMarketingCampaignAdAttributeTypeGrid();
        }

        /// <summary>
        /// Handles the Click event of the btnCancelAttribute control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnCancelAttribute_Click( object sender, EventArgs e )
        {
            pnlDetails.Visible = true;
            pnlAdTypeAttribute.Visible = false;
        }

        /// <summary>
        /// Binds the marketing campaign ad attribute type grid.
        /// </summary>
        private void BindMarketingCampaignAdAttributeTypeGrid()
        {
            gMarketingCampaignAdAttributeTypes.DataSource = AttributesState.OrderBy( a => a.Name ).ToList();
            gMarketingCampaignAdAttributeTypes.DataBind();
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
            MarketingCampaignAdType marketingCampaignAdType;
            MarketingCampaignAdTypeService marketingCampaignAdTypeService = new MarketingCampaignAdTypeService();

            int marketingCampaignAdTypeId = int.Parse( hfMarketingCampaignAdTypeId.Value );

            if ( marketingCampaignAdTypeId == 0 )
            {
                marketingCampaignAdType = new MarketingCampaignAdType();
                marketingCampaignAdTypeService.Add( marketingCampaignAdType, CurrentPersonId );
            }
            else
            {
                marketingCampaignAdType = marketingCampaignAdTypeService.Get( marketingCampaignAdTypeId );
            }

            marketingCampaignAdType.Name = tbName.Text;
            marketingCampaignAdType.DateRangeType = (DateRangeTypeEnum)int.Parse( ddlDateRangeType.SelectedValue );

            // check for duplicates
            if ( marketingCampaignAdTypeService.Queryable().Count( a => a.Name.Equals( marketingCampaignAdType.Name, StringComparison.OrdinalIgnoreCase ) && !a.Id.Equals( marketingCampaignAdType.Id ) ) > 0 )
            {
                tbName.ShowErrorMessage( WarningMessage.DuplicateFoundMessage( "name", MarketingCampaignAdType.FriendlyTypeName ) );
                return;
            }

            if ( !marketingCampaignAdType.IsValid )
            {
                // Controls will render the error messages                    
                return;
            }

            RockTransactionScope.WrapTransaction( () =>
            {
                marketingCampaignAdTypeService.Save( marketingCampaignAdType, CurrentPersonId );

                // get it back to make sure we have a good Id for it for the Attributes
                marketingCampaignAdType = marketingCampaignAdTypeService.Get( marketingCampaignAdType.Guid );

                // delete AdTypeAttributes that are no longer configured in the UI
                AttributeService attributeService = new AttributeService();
                var qry = attributeService.GetByEntityTypeId( new MarketingCampaignAd().TypeId ).AsQueryable()
                    .Where( a => a.EntityTypeQualifierColumn.Equals( "MarketingCampaignAdTypeId", StringComparison.OrdinalIgnoreCase )
                    && a.EntityTypeQualifierValue.Equals( marketingCampaignAdType.Id.ToString() ) );

                var deletedAttributes = from attr in qry
                                        where !( from d in AttributesState
                                                 select d.Guid ).Contains( attr.Guid )
                                        select attr;

                deletedAttributes.ToList().ForEach( a =>
                    {
                        var attr = attributeService.Get( a.Guid );
                        attributeService.Delete( attr, CurrentPersonId );
                        attributeService.Save( attr, CurrentPersonId );
                    } );

                // add/update the AdTypes that are assigned in the UI
                foreach ( var attributeState in AttributesState )
                {
                    Attribute attribute = qry.FirstOrDefault( a => a.Guid.Equals( attributeState.Guid ) );
                    if ( attribute == null )
                    {
                        attribute = attributeState.Clone() as Rock.Model.Attribute;
                        attributeService.Add( attribute, CurrentPersonId );
                    }
                    else
                    {
                        attributeState.Id = attribute.Id;
                        attribute.FromDictionary( attributeState.ToDictionary() );
                    }

                    attribute.EntityTypeQualifierColumn = "MarketingCampaignAdTypeId";
                    attribute.EntityTypeQualifierValue = marketingCampaignAdType.Id.ToString();
                    attribute.EntityTypeId = Rock.Web.Cache.EntityTypeCache.Read( new MarketingCampaignAd().TypeName ).Id;
                    attributeService.Save( attribute, CurrentPersonId );
                }
            } );

            NavigateToParentPage();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Loads the drop downs.
        /// </summary>
        private void LoadDropDowns()
        {
            ddlDateRangeType.BindToEnum( typeof( DateRangeTypeEnum ) );

            FieldTypeService fieldTypeService = new FieldTypeService();
            List<FieldType> fieldTypes = fieldTypeService.Queryable().OrderBy( a => a.Name ).ToList();

            ddlAttributeFieldType.DataSource = fieldTypes;
            ddlAttributeFieldType.DataBind();
        }

        /// <summary>
        /// Shows the detail.
        /// </summary>
        /// <param name="itemKey">The item key.</param>
        /// <param name="itemKeyValue">The item key value.</param>
        public void ShowDetail( string itemKey, int itemKeyValue )
        {
            if ( !itemKey.Equals( "marketingCampaignAdTypeId" ) )
            {
                return;
            }

            pnlDetails.Visible = true;
            MarketingCampaignAdType marketingCampaignAdType = null;

            if ( !itemKeyValue.Equals( 0 ) )
            {
                marketingCampaignAdType = new MarketingCampaignAdTypeService().Get( itemKeyValue );
                lActionTitle.Text = ActionTitle.Edit( MarketingCampaignAdType.FriendlyTypeName );
            }
            else
            {
                marketingCampaignAdType = new MarketingCampaignAdType { Id = 0 };
                lActionTitle.Text = ActionTitle.Add( MarketingCampaignAdType.FriendlyTypeName );
            }

            LoadDropDowns();

            // load data into UI controls
            AttributesState = new ViewStateList<Attribute>();

            hfMarketingCampaignAdTypeId.Value = marketingCampaignAdType.Id.ToString();
            tbName.Text = marketingCampaignAdType.Name;
            ddlDateRangeType.SetValue( (int)marketingCampaignAdType.DateRangeType );

            AttributeService attributeService = new AttributeService();

            var qry = attributeService.GetByEntityTypeId( new MarketingCampaignAd().TypeId ).AsQueryable()
                .Where( a => a.EntityTypeQualifierColumn.Equals( "MarketingCampaignAdTypeId", StringComparison.OrdinalIgnoreCase )
                && a.EntityTypeQualifierValue.Equals( marketingCampaignAdType.Id.ToString() ) );

            AttributesState.AddAll( qry.ToList() );
            BindMarketingCampaignAdAttributeTypeGrid();

            // render UI based on Authorized and IsSystem
            bool readOnly = false;

            nbEditModeMessage.Text = string.Empty;
            if ( !IsUserAuthorized( "Edit" ) )
            {
                readOnly = true;
                nbEditModeMessage.Text = EditModeMessage.ReadOnlyEditActionNotAllowed( MarketingCampaignAdType.FriendlyTypeName );
            }

            if ( marketingCampaignAdType.IsSystem )
            {
                readOnly = true;
                nbEditModeMessage.Text = EditModeMessage.ReadOnlySystem( MarketingCampaignAdType.FriendlyTypeName );
            }

            if ( readOnly )
            {
                lActionTitle.Text = ActionTitle.View( MarketingCampaignAdType.FriendlyTypeName );
                btnCancel.Text = "Close";
            }

            tbName.ReadOnly = readOnly;
            ddlDateRangeType.Enabled = !readOnly;
            gMarketingCampaignAdAttributeTypes.Enabled = !readOnly;

            btnSave.Visible = !readOnly;
        }

        #endregion
    }
}