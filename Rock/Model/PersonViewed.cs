//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Person Viewed POCO Entity.
    /// </summary>
    [Table( "PersonViewed" )]
    [DataContract( IsReference = true )]
    public partial class PersonViewed : Model<PersonViewed>
    {
        /// <summary>
        /// Gets or sets the Viewer Person Id.
        /// </summary>
        /// <value>
        /// Viewer Person Id.
        /// </value>
        [DataMember]
        public int? ViewerPersonId { get; set; }
        
        /// <summary>
        /// Gets or sets the Target Person Id.
        /// </summary>
        /// <value>
        /// Target Person Id.
        /// </value>
        [DataMember]
        public int? TargetPersonId { get; set; }
        
        /// <summary>
        /// Gets or sets the View Date Time.
        /// </summary>
        /// <value>
        /// View Date Time.
        /// </value>
        [DataMember]
        public DateTime? ViewDateTime { get; set; }
        
        /// <summary>
        /// Gets or sets the Ip Address.
        /// </summary>
        /// <value>
        /// Ip Address.
        /// </value>
        [MaxLength( 25 )]
        [DataMember]
        public string IpAddress { get; set; }
        
        /// <summary>
        /// Gets or sets the Source.
        /// </summary>
        /// <value>
        /// Source.
        /// </value>
        [MaxLength( 50 )]
        [DataMember]
        public string Source { get; set; }
        
        /// <summary>
        /// Gets or sets the Viewer Person.
        /// </summary>
        /// <value>
        /// A <see cref="Person"/> object.
        /// </value>
        [DataMember]
        public virtual Person ViewerPerson { get; set; }
        
        /// <summary>
        /// Gets or sets the Target Person.
        /// </summary>
        /// <value>
        /// A <see cref="Person"/> object.
        /// </value>
        [DataMember]
        public virtual Person TargetPerson { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (ViewerPerson != null && TargetPerson != null)
                return string.Format("{0} Viewed {1}", ViewerPerson.FullName, TargetPerson.FullName);
            return string.Empty;
        }
    }

    /// <summary>
    /// Person Viewed Configuration class.
    /// </summary>
    public partial class PersonViewedConfiguration : EntityTypeConfiguration<PersonViewed>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewedConfiguration"/> class.
        /// </summary>
        public PersonViewedConfiguration()
        {
            this.HasOptional( p => p.ViewerPerson ).WithMany().HasForeignKey( p => p.ViewerPersonId ).WillCascadeOnDelete(false);
            this.HasOptional( p => p.TargetPerson ).WithMany().HasForeignKey( p => p.TargetPersonId ).WillCascadeOnDelete(false);
        }
    }
}
