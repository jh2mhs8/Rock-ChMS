//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// ServiceJob Service class
    /// </summary>
    public partial class ServiceJobService : Service<ServiceJob, ServiceJobDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceJobService"/> class
        /// </summary>
        public ServiceJobService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceJobService"/> class
        /// </summary>
        public ServiceJobService(IRepository<ServiceJob> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override ServiceJob CreateNew()
        {
            return new ServiceJob();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<ServiceJobDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<ServiceJobDto> QueryableDto( IQueryable<ServiceJob> items )
        {
            return items.Select( m => new ServiceJobDto()
                {
                    IsSystem = m.IsSystem,
                    IsActive = m.IsActive,
                    Name = m.Name,
                    Description = m.Description,
                    Assembly = m.Assembly,
                    Class = m.Class,
                    CronExpression = m.CronExpression,
                    LastSuccessfulRunDateTime = m.LastSuccessfulRunDateTime,
                    LastRunDateTime = m.LastRunDateTime,
                    LastRunDurationSeconds = m.LastRunDurationSeconds,
                    LastStatus = m.LastStatus,
                    LastStatusMessage = m.LastStatusMessage,
                    LastRunSchedulerName = m.LastRunSchedulerName,
                    NotificationEmails = m.NotificationEmails,
                    NotificationStatus = m.NotificationStatus,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( ServiceJob item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }
}
