//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Compilation;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Workflow POCO Service class
    /// </summary>
    public partial class WorkflowService 
    {
        /// <summary>
        /// Activates a new worflow instance
        /// </summary>
        /// <param name="workflowType">Type of the workflow.</param>
        /// <param name="name">The name.</param>
        /// <param name="currentPersonId">The current person id.</param>
        /// <returns></returns>
        public Workflow Activate( WorkflowType workflowType, string name, int? currentPersonId )
        {
            var workflow = Workflow.Activate( workflowType, name );
            
            this.Add( workflow, currentPersonId );
            this.Save( workflow, currentPersonId );

            return workflow;
        }

        /// <summary>
        /// Processes the specified workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="CurrentPersonId">The current person id.</param>
        /// <param name="errorMessages">The error messages.</param>
        public void Process( Workflow workflow, int? CurrentPersonId, out List<string> errorMessages )
        {
            workflow.IsProcessing = true;
            this.Save( workflow, null );

            workflow.Process(out errorMessages);

            workflow.IsProcessing = false;
            this.Save( workflow, null );
        }

        /// <summary>
        /// Gets the active workflows.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Workflow> GetActive()
        {
            return Repository.AsQueryable()
                .Where( w =>
                    w.ActivatedDateTime.HasValue &&
                    !w.CompletedDateTime.HasValue )
                .OrderBy( w => w.LastProcessedDateTime );
        }

    }
}