﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;

namespace Rock.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        /// <value>
        /// The GUID.
        /// </value>
        Guid Guid { get; set; }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> ToDictionary();

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        dynamic ToDynamic();

        /// <summary>
        /// Copies from model.
        /// </summary>
        /// <param name="model">The model.</param>
        void CopyFromModel( IEntity model );

        /// <summary>
        /// Copies to model.
        /// </summary>
        /// <param name="model">The model.</param>
        void CopyToModel( IEntity model );
    }
}
