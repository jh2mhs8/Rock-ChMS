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
    /// DefinedValue Service class
    /// </summary>
    public partial class DefinedValueService : Service<DefinedValue, DefinedValueDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedValueService"/> class
        /// </summary>
        public DefinedValueService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedValueService"/> class
        /// </summary>
        public DefinedValueService(IRepository<DefinedValue> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override DefinedValue CreateNew()
        {
            return new DefinedValue();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<DefinedValueDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<DefinedValueDto> QueryableDto( IQueryable<DefinedValue> items )
        {
            return items.Select( m => new DefinedValueDto()
                {
                    IsSystem = m.IsSystem,
                    DefinedTypeId = m.DefinedTypeId,
                    Order = m.Order,
                    Name = m.Name,
                    Description = m.Description,
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
        public bool CanDelete( DefinedValue item, out string errorMessage )
        {
            errorMessage = string.Empty;
            
            // ignoring FinancialTransaction,CurrencyTypeValueId 
            
            // ignoring FinancialTransaction,CreditCardTypeValueId 
            
            // ignoring FinancialTransaction,SourceTypeValueId 
 
            if ( new Service<Fund>().Queryable().Any( a => a.FundTypeValueId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DefinedValue.FriendlyTypeName, Fund.FriendlyTypeName );
                return false;
            }  
            
            // ignoring GroupLocation,LocationTypeValueId 
 
            if ( new Service<Metric>().Queryable().Any( a => a.CollectionFrequencyValueId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DefinedValue.FriendlyTypeName, Metric.FriendlyTypeName );
                return false;
            }  
            
            // ignoring Person,MaritalStatusValueId 
            
            // ignoring Person,PersonStatusValueId 
            
            // ignoring Person,RecordStatusValueId 
            
            // ignoring Person,RecordStatusReasonValueId 
            
            // ignoring Person,RecordTypeValueId 
            
            // ignoring Person,SuffixValueId 
            
            // ignoring Person,TitleValueId 
 
            if ( new Service<PhoneNumber>().Queryable().Any( a => a.NumberTypeValueId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DefinedValue.FriendlyTypeName, PhoneNumber.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Pledge>().Queryable().Any( a => a.FrequencyTypeValueId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DefinedValue.FriendlyTypeName, Pledge.FriendlyTypeName );
                return false;
            }  
            return true;
        }
    }
}
