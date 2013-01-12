//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock.Attribute
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public class DetailPageAttribute : FieldAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailPageAttribute" /> class.
        /// </summary>
        public DetailPageAttribute()
            : base( 0, "Detail Page Guid", false, "", Key, "Advanced", "", typeof( Rock.Field.Types.PageReference ).FullName )
        {
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public static new string Key
        {
            get 
            {
                return "DetailPageGuid";
            }
        }
    }
}