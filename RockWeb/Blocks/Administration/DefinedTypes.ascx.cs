//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;

using Rock.Core;
using Rock.Field;
using Rock.Web.UI.Controls;

namespace RockWeb.Blocks.Administration
{
    public partial class DefinedTypes : Rock.Web.UI.Block
    {
        #region Fields

		private const string entity = "Rock.Core.DefinedValue";
		private const string qualifier = "DefinedTypeId";
				
		private Rock.Core.DefinedTypeService typeService = new Rock.Core.DefinedTypeService();
		private Rock.Core.DefinedValueService valueService = new Rock.Core.DefinedValueService();
		private Rock.Core.AttributeService attributeService = new Rock.Core.AttributeService();
		private bool canConfigure = false;
		
		#endregion

		#region Control Methods

		protected override void OnInit( EventArgs e )
		{
			try
			{				
                canConfigure = PageInstance.IsAuthorized( "Configure", CurrentPerson );

                BindFilter();

                if ( canConfigure )
                {                    
                    //assign types grid actions
                    rGridType.DataKeyNames = new string[] { "id" };
                    rGridType.GridRebind += new GridRebindEventHandler( rGridType_GridRebind );
                    rGridType.Actions.IsAddEnabled = true;
					rGridType.Actions.AddClick += rGridType_Add;
                    //rGridType.Actions.ClientAddScript = "editType(0)";

					//assign type values grid actions
					rGridValue.DataKeyNames = new string[] { "id" };
					rGridValue.GridRebind += new GridRebindEventHandler( rGridValue_GridRebind );
					rGridValue.Actions.IsAddEnabled = true;
					rGridValue.Actions.AddClick += rGridValue_Add;
					//rGridValue.Actions.ClientAddScript = "editValue(0)";

                    //assign attributes grid actions
                    rGridAttribute.DataKeyNames = new string[] { "id" };
                    rGridAttribute.GridRebind += new GridRebindEventHandler( rGridAttribute_GridRebind );
                    rGridAttribute.Actions.IsAddEnabled = true;
					rGridAttribute.Actions.AddClick += rGridAttribute_Add;
                    //rGridAttribute.Actions.ClientAddScript = "editAttribute(0)";

					modalAttributes.SaveClick += btnSaveAttribute_Click;
					modalAttributes.OnCancelScript = string.Format( "$('#{0}').val('');", hfIdAttribute.ClientID );

					modalValues.SaveClick += btnSaveValue_Click;
					modalValues.OnCancelScript = string.Format( "$('#{0}').val('');", hfIdValue.ClientID );

					this.Page.ClientScript.RegisterStartupScript( this.GetType(), 
						string.Format( "grid-confirm-delete-{0}", BlockInstance.Id ), @"
                        Sys.Application.add_load(function () {{
                            $('td.grid-icon-cell.delete a').click(function(){{
                                return confirm('Are you sure you want to delete this value?');
                            }});
                        }});", true 
					);

                }
                else
                {
                    DisplayError( "You are not authorized to configure this page" );
                }
            }
            catch ( SystemException ex )
            {
                DisplayError( ex.Message );
            }

            base.OnInit( e );
        }

        protected override void OnLoad( EventArgs e )
        {
            if ( !Page.IsPostBack && canConfigure )
                rGridType_Bind();
 
            base.OnLoad( e );
        }

        #endregion

        #region Events

        protected void ddlCategoryFilter_SelectedIndexChanged( object sender, EventArgs e )
        {
			rGridType_Bind();
        }

		protected void btnSaveType_Click( object sender, EventArgs e )
		{
			
		}

		protected void btnCancelType_Click( object sender, EventArgs e )
		{
			pnlTypeDetails.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnSaveAttribute_Click( object sender, EventArgs e )
		{

		}

		protected void btnCloseAttribute_Click( object sender, EventArgs e )
		{
			pnlAttributes.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnSaveValue_Click( object sender, EventArgs e )
		{

		}

		protected void btnCloseValue_Click( object sender, EventArgs e )
		{
			pnlValues.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnRefresh_Click( object sender, EventArgs e )
		{
			typeId = hfIdType.Value;

			BindFilter();
			rGridType_Bind();
			rGridValue_Bind( typeId );
			rGridAttribute_Bind( typeId );
		}

        #endregion

        #region Edit Methods       
		protected void rGridType_Add( object sender, EventArgs e  )
		{
			ShowEditType( 0 );
		}

		protected void rGridType_EditValue( object sender, RowEventArgs e )
		{
			typeId = hfIdType.Value = rGridType.DataKeys[e.RowIndex]["id"].ToString();
			rGridValue_Bind( typeId );

			pnlTypes.Visible = false;
			pnlValues.Visible = true;
		}

		protected void rGridType_Edit( object sender, RowEventArgs e )
		{
			typeId = hfIdType.Value = rGridType.DataKeys[e.RowIndex]["id"].ToString();
			ShowEditType( typeId );
		}

		protected void rGridType_EditAttribute( object sender, RowEventArgs e ) 
		{
			typeId = hfIdType.Value = rGridType.DataKeys[e.RowIndex]["id"].ToString();
			rGridAttribute_Bind( typeId );

			pnlTypes.Visible = false;
			pnlAttributes.Visible = true;		
		}

		protected void rGridType_Delete( object sender, RowEventArgs e )
		{
			Rock.Core.DefinedType type = typeService.Get( (int)rGridType.DataKeys[e.RowIndex]["id"] );

			if ( type != null )
			{
				Rock.Web.Cache.Attribute.Flush( type.Id );

				// if this DefinedType has DefinedValues, delete them
				var hasDefinedValues = valueService
				.GetByDefinedTypeId( type.Id )
				.ToList();

				foreach ( var value in hasDefinedValues )
				{
					valueService.Delete( value, CurrentPersonId );
					valueService.Save( value, CurrentPersonId );
				}

				typeService.Delete( type, CurrentPersonId );
				typeService.Save( type, CurrentPersonId );
			}

			rGridType_Bind();
		}

		void rGridType_GridRebind( object sender, EventArgs e )
		{
			rGridType_Bind();
		}        
		
		protected void rGridAttribute_Add( object sender, EventArgs e )
		{
			ShowEditAttribute( 0 );
			modalAttributes.Show();
		}		

		protected void rGridAttribute_Edit( object sender, RowEventArgs e )
		{
			attributeId = hfIdAttribute.Value = rGridAttribute.DataKeys[e.RowIndex]["id"].ToString();
			ShowEditAttribute( attributeId );
			modalAttributes.Show();
		}

		protected void rGridAttribute_Delete( object sender, RowEventArgs e )
		{
			Rock.Core.Attribute attribute = attributeService.Get( (int)rGridAttribute.DataKeys[e.RowIndex]["id"] );
			if ( attribute != null )
			{
				Rock.Web.Cache.Attribute.Flush( attribute.Id );

				attributeService.Delete( attribute, CurrentPersonId );
				attributeService.Save( attribute, CurrentPersonId );
			}

			rGridAttribute_Bind( hfIdType.Value );
		}

		void rGridAttribute_GridRebind( )
		{
			rGridAttribute_Bind( hfIdType.Value );
		}
		
        protected void rGridValue_Add( object sender, EventArgs e )
		{
			ShowEditValue( 0 );
			modalValues.Show();
		}

		protected void rGridValue_Edit( object sender, RowEventArgs e )
		{
			valueId = hfIdValue.Value = rGridValue.DataKeys[e.RowIndex]["id"].ToString();
			ShowEditValue( valueId );
		}
				
		protected void rGridValue_Delete( object sender, RowEventArgs e )
		{
			Rock.Core.DefinedValue value = valueService.Get( (int)rGridValue.DataKeys[e.RowIndex]["id"] );

			if ( value != null )
			{
				Rock.Web.Cache.Attribute.Flush( value.Id );

				valueService.Delete( value, CurrentPersonId );
				valueService.Save( value, CurrentPersonId );
			}

			rGridValue_Bind( typeId );
		}
		
		void rGridValue_GridRebind( object sender, EventArgs e )
		{
			rGridValue_Bind( hfIdType.Value );
		}
						        
        #endregion

        #region Internal Methods

        private void BindFilter()
        {
			if ( ddlCategoryFilter.SelectedItem == null )
			{
				ddlCategoryFilter.Items.Clear();
				ddlCategoryFilter.Items.Add( "[All]" );

				DefinedTypeService typeService = new DefinedTypeService();
				var items = typeService.Queryable().
					Where( a => a.Category != "" && a.Category != null ).
					OrderBy( a => a.Category ).
					Select( a => a.Category ).
					Distinct().ToList();

				foreach ( var item in items )
					ddlCategoryFilter.Items.Add( item );
			}
        }

		private void rGridType_Bind()
        {
            var queryable = typeService.Queryable().
                Where( a => a.Category != "" && a.Category != null );

            if ( ddlCategoryFilter.SelectedValue != "[All]" )
                queryable = queryable.
                    Where( a => a.Category == ddlCategoryFilter.SelectedValue );

            rGridType.DataSource = queryable.
                OrderBy( a => a.Category).
                ToList();

            rGridType.DataBind();            
        }

		protected void rGridValue_Bind( string typeId )
		{
			int definedTypeId = Int32.Parse( typeId );
						
			var gridAttributes = attributeService
				.GetAttributesByEntityQualifier( entity, qualifier, typeId )
				.Where( attr => attr.IsGridColumn );

			tbValueGridColumn.Text = string.Join(",",
				gridAttributes.AsEnumerable()
				.Select( attr => attr.Name )
			);
			
			var queryable = valueService.Queryable().
				Where( a => a.DefinedTypeId == definedTypeId );

            rGridValue.DataSource = queryable.
				OrderBy( a => a.Order).
				ToList();

			rGridValue.DataBind();
		}

		protected void rGridAttribute_Bind( string typeId )
        {
            var queryable = attributeService.Queryable().
                Where( a => a.Entity == entity &&
				( a.EntityQualifierColumn ?? string.Empty ) == qualifier &&
				( a.EntityQualifierValue ?? string.Empty ) == typeId );

            rGridAttribute.DataSource = queryable.
                OrderBy( a => a.Category ).
                ThenBy( a => a.Key ).
                ToList();

            rGridAttribute.DataBind();
        }

		protected void ShowEditType( int typeId )
		{
			
			
			pnlTypes.Visible = false;
			pnlTypeDetails.Visible = true;
		}

		protected void ShowEditAttribute( int attributeId )
		{ 
		}

		protected void ShowEditValue( int valueId )
		{
		}
        
        private void DisplayError( string message )
        {
            pnlMessage.Controls.Clear();
            pnlMessage.Controls.Add( new LiteralControl( message ) );
            pnlMessage.Visible = true;

            pnlTypes.Visible = false;
			pnlValues.Visible = false;
			pnlAttributes.Visible = false;
        }

        #endregion
    }
}