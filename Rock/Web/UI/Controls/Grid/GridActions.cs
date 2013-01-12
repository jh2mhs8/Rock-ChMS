﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData( "<{0}:GridActions runat=server></{0}:GridActions>" )]
    public class GridActions : CompositeControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridActions" /> class.
        /// </summary>
        /// <param name="parentGrid">The parent grid.</param>
        public GridActions( Grid parentGrid )
        {
            ParentGrid = parentGrid;
        }

        Grid ParentGrid;

        HtmlGenericControl aAdd;
        LinkButton lbAdd;

        HtmlGenericControl aExcelExport;
        LinkButton lbExcelExport;

        /// <summary>
        /// Gets or sets a value indicating whether [enable add].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable add]; otherwise, <c>false</c>.
        /// </value>
        public bool IsAddEnabled
        {
            get 
            {
                bool? b = ViewState["IsAddEnabled"] as bool?;
                return ( b == null ) ? false : b.Value;
            }
            set
            {
                ViewState["IsAddEnabled"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable add].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable add]; otherwise, <c>false</c>.
        /// </value>
        public bool IsExcelExportEnabled
        {
            get
            {
                bool? b = ViewState["IsExcelExportEnabled"] as bool?;
                return ( b == null ) ? false : b.Value;
            }
            set
            {
                ViewState["IsExcelExportEnabled"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the client add script.
        /// </summary>
        /// <value>
        /// The client add script.
        /// </value>
        public string ClientAddScript
        {
            get
            {
                EnsureChildControls();
                return aAdd.Attributes["onclick"];
            }
            
            set
            {
                EnsureChildControls();
                aAdd.Attributes["onclick"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the client excel export script.
        /// </summary>
        /// <value>
        /// The client excel export script.
        /// </value>
        public string ClientExcelExportScript
        {
            get
            {
                EnsureChildControls();
                return aExcelExport.Attributes["onclick"];
            }

            set
            {
                EnsureChildControls();
                aExcelExport.Attributes["onclick"] = value;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            EnsureChildControls();
            ScriptManager.GetCurrent( Page ).RegisterPostBackControl( lbExcelExport );
        }

        /// <summary>
        /// Writes the <see cref="T:System.Web.UI.WebControls.CompositeControl"/> content to the specified <see cref="T:System.Web.UI.HtmlTextWriter"/> object, for display on the client.
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void Render( HtmlTextWriter writer )
        {
            aAdd.Visible = IsAddEnabled && !String.IsNullOrWhiteSpace( ClientAddScript );
            lbAdd.Visible = IsAddEnabled && String.IsNullOrWhiteSpace( ClientAddScript );

            aExcelExport.Visible = IsExcelExportEnabled && !String.IsNullOrWhiteSpace( ClientExcelExportScript );
            lbExcelExport.Visible = IsExcelExportEnabled && String.IsNullOrWhiteSpace( ClientExcelExportScript );

            base.Render( writer );
        }

        /// <summary>
        /// Recreates the child controls in a control derived from <see cref="T:System.Web.UI.WebControls.CompositeControl"/>.
        /// </summary>
        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag( HtmlTextWriter writer )
        {
            writer.AddAttribute( "class", "grid-actions" );
            base.RenderBeginTag( writer );
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();

            // controls for add
            aAdd = new HtmlGenericControl( "a" );
            Controls.Add( aAdd );
            aAdd.ID = "aAdd";
            aAdd.Attributes.Add( "href", "#" );
            aAdd.Attributes.Add( "class", "add" );
            aAdd.InnerText = "Add";

            lbAdd = new LinkButton();
            Controls.Add( lbAdd );
            lbAdd.ID = "lbAdd";
            lbAdd.CssClass = "add btn";
            lbAdd.ToolTip = "Add";
            lbAdd.Click += lbAdd_Click;
            lbAdd.CausesValidation = false;
            lbAdd.PreRender += lbAdd_PreRender;
            Controls.Add( lbAdd );
            HtmlGenericControl iAdd = new HtmlGenericControl( "i" );
            iAdd.Attributes.Add( "class", "icon-plus-sign" );
            lbAdd.Controls.Add( iAdd );

            // controls for excel export
            aExcelExport = new HtmlGenericControl( "a" );
            Controls.Add( aExcelExport );
            aExcelExport.ID = "aExcelExport";
            aExcelExport.Attributes.Add( "href", "#" );
            aExcelExport.Attributes.Add( "class", "excel-export" );
            aExcelExport.InnerText = "Export To Excel";

            lbExcelExport = new LinkButton();
            Controls.Add( lbExcelExport );
            lbExcelExport.ID = "lbExcelExport";
            lbExcelExport.CssClass = "excel-export btn";
            lbExcelExport.ToolTip = "Export to Excel";
            lbExcelExport.Click += lbExcelExport_Click;
            lbExcelExport.CausesValidation = false;
            Controls.Add( lbExcelExport );
            HtmlGenericControl iExcelExport = new HtmlGenericControl( "i" );
            iExcelExport.Attributes.Add( "class", "icon-table" );
            lbExcelExport.Controls.Add( iExcelExport );
        }

        /// <summary>
        /// Handles the PreRender event of the lbAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void lbAdd_PreRender( object sender, EventArgs e )
        {
            lbAdd.Enabled = ParentGrid.Enabled;
            if ( lbAdd.Enabled )
            {
                lbAdd.Attributes.Remove( "disabled" );
            }
            else
            {
                lbAdd.Attributes["disabled"] = "disabled";
            }
        }

        /// <summary>
        /// Handles the Click event of the lbAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void lbAdd_Click( object sender, EventArgs e )
        {
            if ( AddClick != null )
                AddClick( sender, e );
        }

        /// <summary>
        /// Handles the Click event of the lbExcelExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void lbExcelExport_Click( object sender, EventArgs e )
        {
            if ( ExcelExportClick != null )
                ExcelExportClick( sender, e );
        }

        /// <summary>
        /// Occurs when add action is clicked.
        /// </summary>
        public event EventHandler AddClick;

        /// <summary>
        /// Occurs when add action is clicked.
        /// </summary>
        public event EventHandler ExcelExportClick;
    }
}