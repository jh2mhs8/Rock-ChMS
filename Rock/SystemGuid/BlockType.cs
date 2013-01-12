﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;

namespace Rock.SystemGuid
{
    /// <summary>
    /// System Blocks.  NOTE: Some of these are referenced in Migrations to avoid string-typos.
    /// </summary>
    public static class BlockType
    {
        /// <summary>
        /// Gets the Plugin Manager guid
        /// </summary>
        public static Guid PLUGIN_MANAGER { get { return new Guid( "F80268E6-2625-4565-AA2E-790C5E40A119" ); } }

        /// <summary>
        /// HTML Content Block Type Guid
        /// </summary>
        public static Guid HTML_CONTENT { get { return new Guid( "19B61D65-37E3-459F-A44F-DEF0089118A3" ); } }
    }
}