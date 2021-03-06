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
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Data Transfer Object for WorkflowActivityType object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WorkflowActivityTypeDto : DtoSecured<WorkflowActivityTypeDto>
    {
        /// <summary />
        [DataMember]
        public bool? IsActive { get; set; }

        /// <summary />
        [DataMember]
        public int WorkflowTypeId { get; set; }

        /// <summary />
        [DataMember]
        public string Name { get; set; }

        /// <summary />
        [DataMember]
        public string Description { get; set; }

        /// <summary />
        [DataMember]
        public bool IsActivatedWithWorkflow { get; set; }

        /// <summary />
        [DataMember]
        public int Order { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public WorkflowActivityTypeDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="workflowActivityType"></param>
        public WorkflowActivityTypeDto ( WorkflowActivityType workflowActivityType )
        {
            CopyFromModel( workflowActivityType );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            var dictionary = base.ToDictionary();
            dictionary.Add( "IsActive", this.IsActive );
            dictionary.Add( "WorkflowTypeId", this.WorkflowTypeId );
            dictionary.Add( "Name", this.Name );
            dictionary.Add( "Description", this.Description );
            dictionary.Add( "IsActivatedWithWorkflow", this.IsActivatedWithWorkflow );
            dictionary.Add( "Order", this.Order );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public override dynamic ToDynamic()
        {
            dynamic expando = base.ToDynamic();
            expando.IsActive = this.IsActive;
            expando.WorkflowTypeId = this.WorkflowTypeId;
            expando.Name = this.Name;
            expando.Description = this.Description;
            expando.IsActivatedWithWorkflow = this.IsActivatedWithWorkflow;
            expando.Order = this.Order;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyFromModel( IEntity model )
        {
            base.CopyFromModel( model );

            if ( model is WorkflowActivityType )
            {
                var workflowActivityType = (WorkflowActivityType)model;
                this.IsActive = workflowActivityType.IsActive;
                this.WorkflowTypeId = workflowActivityType.WorkflowTypeId;
                this.Name = workflowActivityType.Name;
                this.Description = workflowActivityType.Description;
                this.IsActivatedWithWorkflow = workflowActivityType.IsActivatedWithWorkflow;
                this.Order = workflowActivityType.Order;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyToModel ( IEntity model )
        {
            base.CopyToModel( model );

            if ( model is WorkflowActivityType )
            {
                var workflowActivityType = (WorkflowActivityType)model;
                workflowActivityType.IsActive = this.IsActive;
                workflowActivityType.WorkflowTypeId = this.WorkflowTypeId;
                workflowActivityType.Name = this.Name;
                workflowActivityType.Description = this.Description;
                workflowActivityType.IsActivatedWithWorkflow = this.IsActivatedWithWorkflow;
                workflowActivityType.Order = this.Order;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class WorkflowActivityTypeDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static WorkflowActivityType ToModel( this WorkflowActivityTypeDto value )
        {
            WorkflowActivityType result = new WorkflowActivityType();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<WorkflowActivityType> ToModel( this List<WorkflowActivityTypeDto> value )
        {
            List<WorkflowActivityType> result = new List<WorkflowActivityType>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<WorkflowActivityTypeDto> ToDto( this List<WorkflowActivityType> value )
        {
            List<WorkflowActivityTypeDto> result = new List<WorkflowActivityTypeDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static WorkflowActivityTypeDto ToDto( this WorkflowActivityType value )
        {
            return new WorkflowActivityTypeDto( value );
        }

    }
}