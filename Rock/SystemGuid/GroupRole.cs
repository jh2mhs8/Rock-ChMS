//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rock.SystemGuid
{
    /// <summary>
    /// Group Role System Guids
    /// </summary>
    public static class GroupRole
    {
        #region Family Members

        /// <summary>
        /// Gets the adult family member role
        /// </summary>
        public static Guid GROUPROLE_FAMILY_MEMBER_ADULT { get { return new Guid( "2639F9A5-2AAE-4E48-A8C3-4FFE86681E42" ); } }
        
        /// <summary>
        /// Gets the child family member role
        /// </summary>
        public static Guid GROUPROLE_FAMILY_MEMBER_CHILD { get { return new Guid( "C8B1814F-6AA7-4055-B2D7-48FE20429CB9" ); } }

        #endregion

        #region Known Relationships

        /// <summary>
        /// Gets the Known Relationships owner role.
        /// </summary>
        /// <value>
        /// The role Guid
        /// </value>
        public static Guid GROUPROLE_KNOWN_RELATIONSHIPS_OWNER { get { return new Guid( "7BC6C12E-0CD1-4DFD-8D5B-1B35AE714C42" ); } }

        #endregion

        #region Implied Relationships

        /// <summary>
        /// Gets the Implied Relationships owner role.
        /// </summary>
        /// <value>
        /// The role Guid.
        /// </value>
        public static Guid GROUPROLE_IMPLIED_RELATIONSHIPS_OWNER { get { return new Guid( "CB9A0E14-6FCF-4C07-A49A-D7873F45E196" ); } }

        /// <summary>
        /// Gets the Implied Relationships related role.
        /// </summary>
        /// <value>
        /// The role Guid.
        /// </value>
        public static Guid GROUPROLE_IMPLIED_RELATIONSHIPS_RELATED { get { return new Guid( "FEA75948-97CB-4DE9-8A0D-43FA2646F55B" ); } }

        #endregion

    }
}