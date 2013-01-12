﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Services;
using System.Runtime.Serialization;

using Rock.Attribute;
using Rock.Model;
using Rock.Security;

namespace Rock.Data
{
    /// <summary>
    /// Represents an entity that can be secured and have attributes. 
    /// </summary>
    [IgnoreProperties( new[] { "ParentAuthority", "SupportedActions", "AuthEntity", "AttributeValues" } )]
    [DataContract( IsReference = true )]
    public abstract class Model<T> : Entity<T>, ISecured, IHasAttributes
        where T : Model<T>, ISecured, new()
    {
        #region ISecured implementation

        /// <summary>
        /// A parent authority.  If a user is not specifically allowed or denied access to
        /// this object, Rock will check the default authorization on the current type, and 
        /// then the authorization on the Rock.Security.GlobalDefault entity
        /// </summary>
        [NotMapped]
        public virtual Security.ISecured ParentAuthority
        { 
            get 
            {
                if ( this.Id == 0 )
                {
                    return new GlobalDefault();
                }
                else
                {
                    return new T() ;
                }
            }
        }

        /// <summary>
        /// A list of actions that this class supports.
        /// </summary>
        [NotMapped]
        public virtual List<string> SupportedActions
        {
            get { return new List<string>() { "View", "Edit", "Administrate" }; }
        }

        /// <summary>
        /// Return <c>true</c> if the user is authorized to perform the selected action on this object.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="person">The person.</param>
        /// <returns>
        ///   <c>true</c> if the specified action is authorized; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsAuthorized( string action, Rock.Model.Person person )
        {
            return Security.Authorization.Authorized( this, action, person );
        }

        /// <summary>
        /// If a user or role is not specifically allowed or denied to perform the selected action,
        /// return <c>true</c> if they should be allowed anyway or <c>false</c> if not.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public virtual bool IsAllowedByDefault( string action )
        {
            return action == "View";
        }

        /// <summary>
        /// Determines whether the specified action is private (Only the current user has access).
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="person">The person.</param>
        /// <returns>
        ///   <c>true</c> if the specified action is private; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsPrivate( string action, Person person )
        {
            return Security.Authorization.IsPrivate( this, action, person );
        }

        /// <summary>
        /// Makes the action on the current entity private (Only the current user will have access).
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="person">The person.</param>
        /// <param name="personId">The current person id.</param>
        public virtual void MakePrivate( string action, Person person, int? personId )
        {
            Security.Authorization.MakePrivate( this, action, person, personId );
        }

        #endregion

        #region IHasAttributes implementation

        // Note: For complex/non-entity types, we'll need to decorate some classes with the IgnoreProperties attribute
        // to tell WCF Data Services not to worry about the associated properties.

        /// <summary>
        /// Dictionary of categorized attributes.  Key is the category name, and Value is list of attributes in the category
        /// </summary>
        /// <value>
        /// The attribute categories.
        /// </value>
        public SortedDictionary<string, List<string>> AttributeCategories { get; set; }

        /// <summary>
        /// List of attributes associated with the object.  This property will not include the attribute values.
        /// The <see cref="AttributeValues"/> property should be used to get attribute values.  Dictionary key
        /// is the attribute key, and value is the cached attribute
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        [NotMapped]
        [DataMember]
        public Dictionary<string, Rock.Web.Cache.AttributeCache> Attributes { get; set; }

        /// <summary>
        /// Dictionary of all attributes and their value.  Key is the attribute key, and value is the values
        /// associated with the attribute and object instance
        /// </summary>
        /// <value>
        /// The attribute values.
        /// </value>
        [NotMapped]
        [DataMember]
        public Dictionary<string, List<Rock.Model.AttributeValue>> AttributeValues { get; set; }

        /// <summary>
        /// Gets the first value of an attribute key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetAttributeValue( string key )
        {
            if ( this.AttributeValues != null &&
                this.AttributeValues.ContainsKey( key ) &&
                this.AttributeValues[key].Count > 0 )
            {
                return this.AttributeValues[key][0].Value;
            }
            return null;
        }

        /// <summary>
        /// Sets the first value of an attribute key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetAttributeValue( string key, string value )
        {
            if ( this.AttributeValues != null &&
                this.AttributeValues.ContainsKey( key ) )
            {
                if ( this.AttributeValues[key].Count == 0 )
                {
                    this.AttributeValues[key].Add(new AttributeValue());
                }
                this.AttributeValues[key][0].Value = value;
            }
        }
        
        #endregion
   }
}
