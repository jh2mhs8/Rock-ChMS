//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;

using Rock.Model;

namespace Rock.Web.UI
{
    /// <summary>
    /// A Block used on the person detail page
    /// </summary>
    [ContextAware( "Rock.Model.Person" )]
    public class PersonBlock : RockBlock
    {
        /// <summary>
        /// The current person being viewed
        /// </summary>
        protected Person Person { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            if ( ContextEntities.ContainsKey( "Rock.Model.Person" ) )
            {
                Person = ContextEntities["Rock.Model.Person"] as Person;
                if ( Person == null )
                    Person = new Person();
            }
        }

        /// <summary>
        /// The groups of a particular type that current person belongs to
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Group> PersonGroups(Guid groupTypeGuid)
        {
            var service = new GroupTypeService();
            int groupTypeId = service.Queryable().Where( g => g.Guid == groupTypeGuid ).Select( g => g.Id ).FirstOrDefault();
            return PersonGroups( groupTypeId );
        }

        /// <summary>
        /// The groups of a particular type that current person belongs to
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Group> PersonGroups( int groupTypeId )
        {
            string itemKey = "RockGroups:" + groupTypeId.ToString();

            var groups = Context.Items[itemKey] as IEnumerable<Group>;
            if ( groups != null )
                return groups;

            if ( Person == null )
                return null;

            var service = new GroupMemberService();
            groups = service.Queryable()
                .Where( m =>
                    m.PersonId == Person.Id &&
                    m.Group.GroupTypeId == groupTypeId )
                .Select( m => m.Group )
                .OrderByDescending( g => g.Name );

            Context.Items.Add( itemKey, groups );

            return groups;
        }
    }

}