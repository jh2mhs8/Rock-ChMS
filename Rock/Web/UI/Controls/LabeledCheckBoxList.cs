﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock.Constants;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// A <see cref="T:System.Web.UI.WebControls.TextBox"/> control with an associated label.
    /// </summary>
    [ToolboxData( "<{0}:LabeledCheckBoxList runat=server></{0}:LabeledCheckBoxList>" )]
    public class LabeledCheckBoxList : CheckBoxList
    {
        private Label label;
        private Label lblNoItemsText;

        /// <summary>
        /// Gets or sets the help tip.
        /// </summary>
        /// <value>
        /// The help tip.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ),
        Description( "The help tip." )
        ]
        public string Tip
        {
            get
            {
                string s = ViewState["Tip"] as string;
                return s == null ? string.Empty : s;
            }
            set
            {
                ViewState["Tip"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the help block.
        /// </summary>
        /// <value>
        /// The help block.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ),
        Description( "The help block." )
        ]
        public string Help
        {
            get
            {
                string s = ViewState["Help"] as string;
                return s == null ? string.Empty : s;
            }
            set
            {
                ViewState["Help"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        /// <value>
        /// The label text.
        /// </value>
        [
        Bindable( true ),
        Category( "Appearance" ),
        DefaultValue( "" ),
        Description( "The text for the label." )
        ]
        public string LabelText
        {
            get
            {
                EnsureChildControls();
                return label.Text;
            }
            set
            {
                EnsureChildControls();
                label.Text = value;
            }
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            label = new Label();
            label.AssociatedControlID = this.ID;
            Controls.Add( label );

            lblNoItemsText = new Label { Text = None.TextHtml };
            Controls.Add( lblNoItemsText );
        }

        /// <summary>
        /// Renders a label and <see cref="T:System.Web.UI.WebControls.TextBox"/> control to the specified <see cref="T:System.Web.UI.HtmlTextWriter"/> object.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> that receives the rendered output.</param>
        protected override void Render( HtmlTextWriter writer )
        {
            writer.AddAttribute( "class", "control-group" );
            writer.RenderBeginTag( HtmlTextWriterTag.Div );

            label.AddCssClass( "control-label" );
            label.RenderControl( writer );

            if ( Items.Count == 0 )
            {
                writer.RenderBeginTag( HtmlTextWriterTag.Div );
                lblNoItemsText.RenderControl( writer );
                writer.RenderEndTag();
            }

            writer.AddAttribute( "class", "controls checkbox" );
            writer.RenderBeginTag( HtmlTextWriterTag.Div );

            //writer.AddAttribute( "class", "checkbox" );
            //writer.RenderBeginTag( HtmlTextWriterTag.Label );

            base.Render( writer );

            writer.RenderEndTag();

            if ( Tip.Trim() != string.Empty )
            {
                writer.AddAttribute( "class", "help-tip" );
                writer.AddAttribute( "href", "#" );
                writer.RenderBeginTag( HtmlTextWriterTag.A );
                writer.RenderBeginTag( HtmlTextWriterTag.Span );
                writer.Write( Tip.Trim() );
                writer.RenderEndTag();
                writer.RenderEndTag();
            }

            if ( Help.Trim() != string.Empty )
            {
                writer.AddAttribute( "class", "help-block" );
                writer.RenderBeginTag( HtmlTextWriterTag.P );
                writer.Write( Help.Trim() );
                writer.RenderEndTag();
            }

            //writer.RenderEndTag();

            writer.RenderEndTag();
        }

    }
}