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

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class CampusPicker : LabeledCheckBoxList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampusPicker" /> class.
        /// </summary>
        public CampusPicker()
            : base()
        {
            LabelText = "Campuses";
        }

        /// <summary>
        /// Gets or sets the campuses.
        /// </summary>
        /// <value>
        /// The campuses.
        /// </value>
        public List<Campus> Campuses
        {
            set
            {
                this.Items.Clear();
                foreach ( Campus campus in value )
                {
                    ListItem campusItem = new ListItem();
                    campusItem.Value = campus.Id.ToString();
                    campusItem.Text = campus.Name;
                    this.Items.Add( campusItem );
                }

            }
        }

        /// <summary>
        /// Gets the available campus ids.
        /// </summary>
        /// <value>
        /// The available campus ids.
        /// </value>
        public List<int> AvailableCampusIds
        {
            get
            {
                return this.Items.OfType<ListItem>().Select( a => int.Parse( a.Value ) ).ToList();
            }
        }

        /// <summary>
        /// Gets the selected campus ids.
        /// </summary>
        /// <value>
        /// The selected campus ids.
        /// </value>
        public List<int> SelectedCampusIds
        {
            get
            {
                return this.Items.OfType<ListItem>().Where( l => l.Selected ).Select( a => int.Parse( a.Value ) ).ToList();
            }
            set
            {
                foreach ( ListItem campusItem in this.Items )
                {
                    campusItem.Selected = value.Exists( a => a.Equals( int.Parse( campusItem.Value ) ) );
                }
            }
        }

    }
}