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
    /// Data Transfer Object for PersonMerged object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class PersonMergedDto : DtoSecured<PersonMergedDto>
    {
        /// <summary />
        [DataMember]
        public int CurrentId { get; set; }

        /// <summary />
        [DataMember]
        public Guid CurrentGuid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public PersonMergedDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="personMerged"></param>
        public PersonMergedDto ( PersonMerged personMerged )
        {
            CopyFromModel( personMerged );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            var dictionary = base.ToDictionary();
            dictionary.Add( "CurrentId", this.CurrentId );
            dictionary.Add( "CurrentGuid", this.CurrentGuid );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public override dynamic ToDynamic()
        {
            dynamic expando = base.ToDynamic();
            expando.CurrentId = this.CurrentId;
            expando.CurrentGuid = this.CurrentGuid;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyFromModel( IEntity model )
        {
            base.CopyFromModel( model );

            if ( model is PersonMerged )
            {
                var personMerged = (PersonMerged)model;
                this.CurrentId = personMerged.CurrentId;
                this.CurrentGuid = personMerged.CurrentGuid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyToModel ( IEntity model )
        {
            base.CopyToModel( model );

            if ( model is PersonMerged )
            {
                var personMerged = (PersonMerged)model;
                personMerged.CurrentId = this.CurrentId;
                personMerged.CurrentGuid = this.CurrentGuid;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class PersonMergedDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static PersonMerged ToModel( this PersonMergedDto value )
        {
            PersonMerged result = new PersonMerged();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<PersonMerged> ToModel( this List<PersonMergedDto> value )
        {
            List<PersonMerged> result = new List<PersonMerged>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<PersonMergedDto> ToDto( this List<PersonMerged> value )
        {
            List<PersonMergedDto> result = new List<PersonMergedDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static PersonMergedDto ToDto( this PersonMerged value )
        {
            return new PersonMergedDto( value );
        }

    }
}