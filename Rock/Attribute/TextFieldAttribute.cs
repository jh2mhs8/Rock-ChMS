﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

namespace Rock.Attribute
{
    /// <summary>
    /// A class Attribute that can be used by any oject that inherits from <see cref="Rock.Attribute.IHasAttributes"/> to specify what attributes it needs.  The 
    /// Framework provides methods in the <see cref="Rock.Attribute.Helper"/> class to create, read, and update the attributes
    /// </summary>
    /// <remarks>
    /// If using a custom <see cref="Rock.Field.IFieldType"/> make sure that the fieldtype has been added to Rock.
    /// </remarks>
    public class TextFieldAttribute : FieldAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFieldAttribute" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        public TextFieldAttribute( int order, string name, string description, bool required )
            : base( order, name, required, string.Empty, null, string.Empty, description )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFieldAttribute" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="defaultValue">The default value.</param>
        public TextFieldAttribute( int order, string name, string category, string description, bool required, string defaultValue )
            : base( order, name, required, defaultValue, null, category, description )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFieldAttribute" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="name">The name.</param>
        /// <param name="key">The key.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="defaultValue">The default value.</param>

        public TextFieldAttribute( int order, string name, string key, string category, string description, bool required, string defaultValue )
            : base( order, name, required, defaultValue, key, category, description )
        {
        }
    }
}