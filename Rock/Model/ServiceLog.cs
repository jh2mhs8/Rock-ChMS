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
    /// Service Log POCO Entity.
    /// </summary>
    [Table( "ServiceLog" )]
    [DataContract( IsReference = true )]
    public partial class ServiceLog : Model<ServiceLog>
    {
        /// <summary>
        /// Gets or sets the Time.
        /// </summary>
        /// <value>
        /// Time.
        /// </value>
        [DataMember]
        public DateTime? Time { get; set; }
        
        /// <summary>
        /// Gets or sets the Input.
        /// </summary>
        /// <value>
        /// Input.
        /// </value>
        [DataMember]
        public string Input { get; set; }
        
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        /// <value>
        /// Type.
        /// </value>
        [MaxLength( 50 )]
        [DataMember]
        public string Type { get; set; }
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
        [MaxLength( 50 )]
        [DataMember]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the Result.
        /// </summary>
        /// <value>
        /// Result.
        /// </value>
        [MaxLength( 50 )]
        [DataMember]
        public string Result { get; set; }
        
        /// <summary>
        /// Gets or sets the Success.
        /// </summary>
        /// <value>
        /// Success.
        /// </value>
        [Required]
        [DataMember( IsRequired = true )]
        public bool Success { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }

    }

    /// <summary>
    /// Service Log Configuration class.
    /// </summary>
    public partial class ServiceLogConfiguration : EntityTypeConfiguration<ServiceLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLogConfiguration"/> class.
        /// </summary>
        public ServiceLogConfiguration()
        {
        }
    }
}
