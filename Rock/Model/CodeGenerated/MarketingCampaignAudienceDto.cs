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
    /// Data Transfer Object for MarketingCampaignAudience object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class MarketingCampaignAudienceDto : DtoSecured<MarketingCampaignAudienceDto>
    {
        /// <summary />
        [DataMember]
        public int MarketingCampaignId { get; set; }

        /// <summary />
        [DataMember]
        public int AudienceTypeValueId { get; set; }

        /// <summary />
        [DataMember]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public MarketingCampaignAudienceDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="marketingCampaignAudience"></param>
        public MarketingCampaignAudienceDto ( MarketingCampaignAudience marketingCampaignAudience )
        {
            CopyFromModel( marketingCampaignAudience );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            var dictionary = base.ToDictionary();
            dictionary.Add( "MarketingCampaignId", this.MarketingCampaignId );
            dictionary.Add( "AudienceTypeValueId", this.AudienceTypeValueId );
            dictionary.Add( "IsPrimary", this.IsPrimary );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public override dynamic ToDynamic()
        {
            dynamic expando = base.ToDynamic();
            expando.MarketingCampaignId = this.MarketingCampaignId;
            expando.AudienceTypeValueId = this.AudienceTypeValueId;
            expando.IsPrimary = this.IsPrimary;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyFromModel( IEntity model )
        {
            base.CopyFromModel( model );

            if ( model is MarketingCampaignAudience )
            {
                var marketingCampaignAudience = (MarketingCampaignAudience)model;
                this.MarketingCampaignId = marketingCampaignAudience.MarketingCampaignId;
                this.AudienceTypeValueId = marketingCampaignAudience.AudienceTypeValueId;
                this.IsPrimary = marketingCampaignAudience.IsPrimary;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyToModel ( IEntity model )
        {
            base.CopyToModel( model );

            if ( model is MarketingCampaignAudience )
            {
                var marketingCampaignAudience = (MarketingCampaignAudience)model;
                marketingCampaignAudience.MarketingCampaignId = this.MarketingCampaignId;
                marketingCampaignAudience.AudienceTypeValueId = this.AudienceTypeValueId;
                marketingCampaignAudience.IsPrimary = this.IsPrimary;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class MarketingCampaignAudienceDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static MarketingCampaignAudience ToModel( this MarketingCampaignAudienceDto value )
        {
            MarketingCampaignAudience result = new MarketingCampaignAudience();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<MarketingCampaignAudience> ToModel( this List<MarketingCampaignAudienceDto> value )
        {
            List<MarketingCampaignAudience> result = new List<MarketingCampaignAudience>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<MarketingCampaignAudienceDto> ToDto( this List<MarketingCampaignAudience> value )
        {
            List<MarketingCampaignAudienceDto> result = new List<MarketingCampaignAudienceDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static MarketingCampaignAudienceDto ToDto( this MarketingCampaignAudience value )
        {
            return new MarketingCampaignAudienceDto( value );
        }

    }
}