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

		private string _entityType = typeof( Rock.Core.DefinedValue ).ToString();
		private string _entityQualifier = "DefinedTypeId";
						
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
                canConfigure = CurrentPage.IsAuthorized( "Configure", CurrentPerson );

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
						string.Format( "grid-confirm-delete-{0}", CurrentBlock.Id ), @"
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
			using ( new Rock.Data.UnitOfWorkScope() )
			{
				typeService = new Rock.Core.DefinedTypeService();

				Rock.Core.DefinedType definedType;

				int typeId = (( hfIdType.Value ) != null && hfIdType.Value != String.Empty ) ? Int32.Parse( hfIdType.Value ) : 0;

				if ( typeId == 0 )
				{
					definedType = new Rock.Core.DefinedType();
					definedType.IsSystem = false;
					definedType.Order = 0;
					typeService.Add( definedType, CurrentPersonId );
				}
				else
				{
					Rock.Web.Cache.DefinedTypeCache.Flush( typeId );
					definedType = typeService.Get( typeId );
				}

				definedType.Name = tbTypeName.Text;
				definedType.Category = tbTypeCategory.Text;
				definedType.Description = tbTypeDescription.Text;
				//definedType.FieldType = ddlTypeFieldType.SelectedValue;
				definedType.FieldTypeId = Int32.Parse( ddlTypeFieldType.SelectedValue );
				
				typeService.Save( definedType, CurrentPersonId );
			}

			rGridType_Bind();

			pnlTypeDetails.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnCancelType_Click( object sender, EventArgs e )
		{
			pnlTypeDetails.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnSaveAttribute_Click( object sender, EventArgs e )
		{
			using ( new Rock.Data.UnitOfWorkScope() )
			{
				attributeService = new AttributeService();

				Rock.Core.Attribute attribute;

				int attributeId = ( ( hfIdAttribute.Value ) != null && hfIdAttribute.Value != String.Empty ) ? Int32.Parse( hfIdAttribute.Value ) : 0;
				if ( attributeId == 0 )
				{
					attribute = new Rock.Core.Attribute();
					attribute.IsSystem = false;
					attribute.Entity = _entityType;
					attribute.EntityQualifierColumn = _entityQualifier;
				}
				else
				{
					Rock.Web.Cache.AttributeCache.Flush( attributeId );
					attribute = attributeService.Get( attributeId );
				}

				attribute.Key = tbAttributeKey.Text;
				attribute.Name = tbAttributeName.Text;
				attribute.Category = tbAttributeCategory.Text;
				attribute.Description = tbAttributeDescription.Text;
				attribute.FieldTypeId = Int32.Parse( ddlAttributeFieldType.SelectedValue );
				attribute.DefaultValue = tbAttributeDefaultValue.Text;
				attribute.IsGridColumn = cbAttributeGridColumn.Checked;
				attribute.IsRequired = cbAttributeRequired.Checked;
				attribute.EntityQualifierValue = hfIdType.Value;

				attributeService.Save( attribute, CurrentPersonId );
			}

			rGridAttribute_Bind( hfIdType.Value );

			modalAttributes.Hide();
			pnlAttributes.Visible = true;
		}

		protected void btnCloseAttribute_Click( object sender, EventArgs e )
		{
			pnlAttributes.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnSaveValue_Click( object sender, EventArgs e )
		{
			using ( new Rock.Data.UnitOfWorkScope() )
			{
				valueService = new DefinedValueService();

				Rock.Core.DefinedValue definedValue;

				int valueId = ( ( hfIdValue.Value ) != null && hfIdValue.Value != String.Empty ) ? Int32.Parse( hfIdValue.Value ) : 0;
				if ( valueId == 0 )
				{
					definedValue = new Rock.Core.DefinedValue();
					definedValue.IsSystem = false;					
				}
				else
				{
					Rock.Web.Cache.AttributeCache.Flush( valueId );
					definedValue = valueService.Get( valueId );
				}

				definedValue.Name = tbValueName.Text;
				definedValue.Description = tbValueDescription.Text;
				definedValue.DefinedTypeId = Int32.Parse( hfIdType.Value );
				
				valueService.Save( definedValue, CurrentPersonId );
			}

			rGridValue_Bind( hfIdType.Value );

			modalValues.Hide();
			pnlValues.Visible = true;
		}

		protected void btnCloseValue_Click( object sender, EventArgs e )
		{
			pnlValues.Visible = false;
			pnlTypes.Visible = true;
		}

		protected void btnRefresh_Click( object sender, EventArgs e )
		{
			BindFilter();
			rGridType_Bind();
			rGridValue_Bind( hfIdType.Value );
			rGridAttribute_Bind( hfIdType.Value );
		}

        #endregion

        #region Edit Methods       
		protected void rGridType_Add( object sender, EventArgs e  )
		{
			ShowEditType( 0 );
		}

		protected void rGridType_EditValue( object sender, CommandEventArgs e )
		{
			
			//rGridType.DataKeys[
			//hfIdType.Value = rGridType.DataKeys[e.RowIndex]["id"].ToString();
			hfIdType.Value = e.CommandArgument.ToString();			
			rGridValue_Bind( hfIdType.Value );			
			
			pnlTypes.Visible = false;
			pnlValues.Visible = true;
		}

		protected void rGridType_Edit( object sender, RowEventArgs e )
		{
			hfIdType.Value = rGridType.DataKeys[e.RowIndex]["id"].ToString();
			ShowEditType( Int32.Parse(hfIdType.Value) );
		}

		protected void rGridType_EditAttribute( object sender, RowEventArgs e ) 
		{
			hfIdType.Value = rGridType.DataKeys[e.RowIndex]["id"].ToString();
			rGridAttribute_Bind( hfIdType.Value );

			pnlTypes.Visible = false;
			pnlAttributes.Visible = true;		
		}

		protected void rGridType_Delete( object sender, RowEventArgs e )
		{
			Rock.Core.DefinedType type = typeService.Get( (int)rGridType.DataKeys[e.RowIndex]["id"] );

			if ( type != null )
			{
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
			hfIdAttribute.Value = rGridAttribute.DataKeys[e.RowIndex]["id"].ToString();
			ShowEditAttribute( Int32.Parse(hfIdAttribute.Value) );
			modalAttributes.Show();
		}

		protected void rGridAttribute_Delete( object sender, RowEventArgs e )
		{
			Rock.Core.Attribute attribute = attributeService.Get( (int)rGridAttribute.DataKeys[e.RowIndex]["id"] );
			if ( attribute != null )
			{
				attributeService.Delete( attribute, CurrentPersonId );
				attributeService.Save( attribute, CurrentPersonId );
			}

			rGridAttribute_Bind( hfIdType.Value );
		}

		void rGridAttribute_GridRebind( object sender, EventArgs e )
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
			hfIdValue.Value = rGridValue.DataKeys[e.RowIndex]["id"].ToString();
			ShowEditValue( Int32.Parse(hfIdValue.Value) );
		}
				
		protected void rGridValue_Delete( object sender, RowEventArgs e )
		{
			Rock.Core.DefinedValue value = valueService.Get( (int)rGridValue.DataKeys[e.RowIndex]["id"] );

			if ( value != null )
			{
				valueService.Delete( value, CurrentPersonId );
				valueService.Save( value, CurrentPersonId );
			}

			rGridValue_Bind( hfIdType.Value );
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
				.GetAttributesByEntityQualifier( typeof( Rock.Core.DefinedValue).ToString()
					, _entityQualifier
					, typeId )
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
				Where( a => a.Entity == _entityType &&
				( a.EntityQualifierColumn ?? string.Empty ) == _entityQualifier &&
				( a.EntityQualifierValue ?? string.Empty ) == typeId );

            rGridAttribute.DataSource = queryable.
                OrderBy( a => a.Category ).
                ThenBy( a => a.Key ).
                ToList();

            rGridAttribute.DataBind();
        }

		protected void ShowEditType( int typeId )
		{
			var typeModel = new Rock.Core.DefinedTypeService().Get( typeId );

			if ( typeModel != null )
			{
				var type = Rock.Web.Cache.DefinedTypeCache.Read( typeModel );
				lType.Text = "Editing Defined Type";
				hfIdType.Value = typeId.ToString();
				tbTypeName.Text = type.Name;
				tbTypeCategory.Text = type.Category;
				tbTypeDescription.Text = type.Description;
				if ( type.FieldTypeId != null )
				{
					ddlTypeFieldType.SelectedValue = type.FieldTypeId.ToString();
				}
				
			}
			else
			{
				lType.Text = "Adding Defined Type";
				hfIdType.Value = string.Empty;
				tbTypeName.Text = string.Empty;
				tbTypeCategory.Text = string.Empty;
				tbTypeDescription.Text = string.Empty;
			}
						
			pnlTypes.Visible = false;
			pnlTypeDetails.Visible = true;
		}

		protected void ShowEditAttribute( int attributeId )
		{
			var attributeModel = new Rock.Core.AttributeService().Get( attributeId );

			if ( attributeModel != null )
			{
				var attribute = Rock.Web.Cache.AttributeCache.Read( attributeModel );
				hfIdAttribute.Value = attributeId.ToString();
				tbAttributeKey.Text = attribute.Key;
				tbAttributeName.Text = attribute.Name;
				tbAttributeCategory.Text = attribute.Category;
				tbAttributeDescription.Text = attribute.Description;
				tbAttributeDefaultValue.Text = attribute.DefaultValue;
				cbAttributeGridColumn.Checked = attribute.IsGridColumn;
				cbAttributeRequired.Checked = attribute.IsRequired;
				if (attribute.FieldTypeId != null)
				{
					ddlAttributeFieldType.SelectedValue = attribute.FieldTypeId.ToString();
				}

			}
			else
			{
				hfIdAttribute.Value = string.Empty;
				tbAttributeKey.Text = string.Empty;
				tbAttributeName.Text = string.Empty;
				tbAttributeCategory.Text = string.Empty;
				tbAttributeDescription.Text = string.Empty;
				tbAttributeDefaultValue.Text = string.Empty;				
			}

			pnlAttributes.Visible = false;
			modalAttributes.Show();
		}

		protected void ShowEditValue( int valueId )
		{
			var valueModel = new Rock.Core.DefinedValueService().Get( valueId );

			if ( valueModel != null )
			{
				var value = Rock.Web.Cache.DefinedValueCache.Read( valueModel );
				var gridAttributes = attributeService
					.GetAttributesByEntityQualifier( _entityType, _entityQualifier, hfIdType.Value)
					.Where( attr => attr.IsGridColumn );
				
				hfIdValue.Value = valueId.ToString();
				tbValueName.Text = value.Name;
				tbValueDescription.Text = value.Description;
				tbValueGridColumn.Text = string.Join( ",",gridAttributes.AsEnumerable()
					.Select( attr => attr.Name )
			);
			}
			else
			{
				hfIdValue.Value = string.Empty;

				tbValueName.Text = string.Empty;
				tbValueDescription.Text = string.Empty;
				tbValueGridColumn.Text = string.Empty;				
			}

			pnlValues.Visible = false;
			modalValues.Show();
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