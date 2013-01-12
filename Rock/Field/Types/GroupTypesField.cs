//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Rock.Model;
using Rock.Web.UI.Controls;

namespace Rock.Field.Types
{
    /// <summary>
    /// Field Type to select 0 or more GroupTypes 
    /// </summary>
    public class GroupTypesField : FieldType
    {
        /// <summary>
        /// Creates the control(s) neccessary for prompting user for a new value
        /// </summary>
        /// <param name="configurationValues">The configuration values.</param>
        /// <returns>
        /// The control
        /// </returns>
        public override System.Web.UI.Control EditControl( Dictionary<string, ConfigurationValue> configurationValues )
        {
            LabeledCheckBoxList editControl = new LabeledCheckBoxList();

            GroupTypeService groupTypeService = new GroupTypeService();
            var groupTypes = groupTypeService.Queryable().OrderBy( a => a.Name ).ToList();
            foreach ( var groupType in groupTypes )
            {
                ListItem listItem = new ListItem( groupType.Name, groupType.Id.ToString() );
                editControl.Items.Add(listItem);
            }

            return editControl;
        }

        /// <summary>
        /// Reads new values entered by the user for the field
        /// </summary>
        /// <param name="control">Parent control that controls were added to in the CreateEditControl() method</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <returns></returns>
        public override string GetEditValue( System.Web.UI.Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            List<string> values = new List<string>();

            if ( control != null && control is ListControl )
            {
                LabeledCheckBoxList cbl = (LabeledCheckBoxList)control;
                foreach ( ListItem li in cbl.Items )
                    if ( li.Selected )
                        values.Add( li.Value );
                return values.AsDelimited<string>( "," );
            }

            return null;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="value">The value.</param>
        public override void SetEditValue( System.Web.UI.Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            List<string> values = new List<string>();
            values.AddRange( value.Split( ',' ) );

            if ( control != null && control is ListControl )
            {
                LabeledCheckBoxList cbl = (LabeledCheckBoxList)control;
                foreach ( ListItem li in cbl.Items )
                    li.Selected = values.Contains( li.Value );
            }
        }
    }
}