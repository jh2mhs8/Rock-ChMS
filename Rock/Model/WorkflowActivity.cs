//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Activity POCO Entity.
    /// </summary>
    [Table( "WorkflowActivity" )]
    [DataContract( IsReference = true )]
    public partial class WorkflowActivity : Model<WorkflowActivity>
    {

        #region Entity Properties

        /// <summary>
        /// Gets or sets the workflow id.
        /// </summary>
        /// <value>
        /// The workflow id.
        /// </value>
        [DataMember]
        public int WorkflowId { get; set; }

        /// <summary>
        /// Gets or sets the activity type id.
        /// </summary>
        /// <value>
        /// The activity type id.
        /// </value>
        [DataMember]
        public int ActivityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the activated date time.
        /// </summary>
        /// <value>
        /// The activated date time.
        /// </value>
        [DataMember]
        public DateTime? ActivatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the last processed date time.
        /// </summary>
        /// <value>
        /// The last processed date time.
        /// </value>
        [DataMember]
        public DateTime? LastProcessedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the completed date time.
        /// </summary>
        /// <value>
        /// The completed date time.
        /// </value>
        [DataMember]
        public DateTime? CompletedDateTime { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// Gets or sets the  workflow.
        /// </summary>
        /// <value>
        /// The workflow.
        /// </value>
        [DataMember]
        public virtual Workflow Workflow { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        /// <value>
        /// The type of the activity.
        /// </value>
        [DataMember]
        public virtual WorkflowActivityType ActivityType { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsActive
        {
            get
            {
                return ActivatedDateTime.HasValue && !CompletedDateTime.HasValue;
            }
        }

        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        /// <value>
        /// The activities.
        /// </value>
        [DataMember]
        public virtual ICollection<WorkflowAction> Actions
        {
            get { return _actions ?? ( _actions = new Collection<WorkflowAction>() ); }
            set { _actions = value; }
        }
        private ICollection<WorkflowAction> _actions;

        /// <summary>
        /// Gets the active actions.
        /// </summary>
        /// <value>
        /// The active actions.
        /// </value>
        public virtual IEnumerable<Rock.Model.WorkflowAction> ActiveActions
        {
            get
            {
                return this.Actions
                    .Where( a => a.IsActive )
                    .OrderBy( a => a.ActionType.Order );
            }
        }

        /// <summary>
        /// Gets the parent authority.
        /// </summary>
        /// <value>
        /// The parent authority.
        /// </value>
        public override Security.ISecured ParentAuthority
        {
            get
            {
                return this.Workflow;
            }
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Processes this instance.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        internal virtual bool Process( IEntity entity, out List<string> errorMessages )
        {
            AddSystemLogEntry( "Processing..." );

            this.LastProcessedDateTime = DateTime.Now;

            errorMessages = new List<string>();

            foreach ( var action in this.ActiveActions )
            {
                List<string> actionErrorMessages;
                bool actionSuccess = action.Process( entity, out actionErrorMessages );
                errorMessages.AddRange( actionErrorMessages );

                // If action was not successful, exit
                if ( !actionSuccess )
                {
                    break;
                }

                // If action completed this activity, exit
                if ( !this.IsActive )
                {
                    break;
                }

                // If action completed this workflow, exit
                if ( !this.Workflow.IsActive )
                {
                    break;
                }
            }

            AddSystemLogEntry( "Processing Complete" );

            return errorMessages.Count == 0;
        }

        /// <summary>
        /// Adds a log entry.
        /// </summary>
        /// <param name="logEntry">The log entry.</param>
        public virtual void AddLogEntry( string logEntry )
        {
            if ( this.Workflow != null )
            {
                this.Workflow.AddLogEntry( string.Format( "'{0}' Activity: {1}", this.ToString(), logEntry ) );
            }
        }

        /// <summary>
        /// Marks this activity as complete.
        /// </summary>
        public virtual void MarkComplete()
        {
            CompletedDateTime = DateTime.Now;
            AddSystemLogEntry( "Completed" );
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format( "{0}[{1}]", this.ActivityType.ToString(), this.Id );
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Logs a system event.
        /// </summary>
        /// <param name="logEntry">The log entry.</param>
        private void AddSystemLogEntry( string logEntry )
        {
            if ( this.Workflow != null &&
                this.Workflow.WorkflowType != null &&
                ( this.Workflow.WorkflowType.LoggingLevel == WorkflowLoggingLevel.Activity ||
                this.Workflow.WorkflowType.LoggingLevel == WorkflowLoggingLevel.Action ) )
            {
                AddLogEntry( logEntry );
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Activates the specified activity type.
        /// </summary>
        /// <param name="activityType">Type of the activity.</param>
        /// <param name="workflow">The workflow.</param>
        /// <returns></returns>
        public static WorkflowActivity Activate( WorkflowActivityType activityType, Workflow workflow )
        {
            var activity = new WorkflowActivity();
            activity.Workflow = workflow;
            activity.ActivityType = activityType;
            activity.ActivatedDateTime = DateTime.Now;
            activity.LoadAttributes();

            activity.AddSystemLogEntry( "Activated" );

            foreach ( var actionType in activityType.ActionTypes )
            {
                activity.Actions.Add( WorkflowAction.Activate(actionType, activity) );
            }

            workflow.Activities.Add( activity );

            return activity;
        }

        #endregion

    }

    #region Entity Configuration

    /// <summary>
    /// Activity Configuration class.
    /// </summary>
    public partial class WorkflowActivityConfiguration : EntityTypeConfiguration<WorkflowActivity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowActivityConfiguration"/> class.
        /// </summary>
        public WorkflowActivityConfiguration()
        {
            this.HasRequired( m => m.Workflow ).WithMany( m => m.Activities).HasForeignKey( m => m.WorkflowId ).WillCascadeOnDelete( true );
            this.HasRequired( m => m.ActivityType ).WithMany().HasForeignKey( m => m.ActivityTypeId).WillCascadeOnDelete( false );
        }
    }

    #endregion

}

