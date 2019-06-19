﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 36, "1.6.9" )]
    public class PrayerRequestFollowingEvent : Migration
    {
        /// <summary>
        /// The commands to run to migrate plugin to the specific version
        /// </summary>
        public override void Up()
        {
            // NOTE: Moved all these to various migrations. See below...
            
            // Moved to core migration: 201711271827181_V7Rollup            
            //            RockMigrationHelper.UpdateEntityType( "Rock.Follow.Event.PersonPrayerRequest", "DAE05FAE-A26F-465A-836C-BAA0EFA1267B", false, true );

            //            Sql( @"
            //    IF NOT EXISTS ( SELECT [Id] FROM [FollowingEventType] WHERE [Guid] = '0323D1DE-616B-4060-AF72-1F17FEEA648F' )
            //    BEGIN

            //        DECLARE @PersonAliasEntityTypeId int = ( SELECT TOP 1 [Id] FROM [EntityType] WHERE [Name] = 'Rock.Model.PersonAlias' )
            //        DECLARE @EntityTypeId int = ( SELECT TOP 1 [Id] FROM [EntityType] WHERE [Guid] = 'DAE05FAE-A26F-465A-836C-BAA0EFA1267B' )

            //        INSERT INTO [FollowingEventType] ( [Name], [Description], [EntityTypeId], [FollowedEntityTypeId], [IsActive], [SendOnWeekends], [IsNoticeRequired], [EntityNotificationFormatLava], [Guid] )
            //	    VALUES 
            //	        ( 'Prayer Requests', 'Person submitted a public prayer request', @EntityTypeId, @PersonAliasEntityTypeId, 1, 0, 0, 
            //'<tr>
            //    <td style=''padding-bottom: 12px; padding-right: 12px; min-width: 87px;''>
            //        {% if Entity.Person.PhotoId %} 
            //            <img src=''{{ ''Global'' | Attribute:''PublicApplicationRoot'' }}GetImage.ashx?id={{ Entity.Person.PhotoId }}&maxwidth=75&maxheight=75''/>
            //        {% endif %}
            //    </td>
            //    <td valign=""top"" style=''padding-bottom: 12px; min-width: 300px;''>
            //        <strong><a href=""{{ ''Global'' | Attribute:''PublicApplicationRoot'' }}Person/{{ Entity.PersonId }}"">{{ Entity.Person.FullName }}</a> 
            //        recently submitted a public prayer request.</strong><br />

            //        {% if Entity.Person.Email != empty %}
            //            Email: <a href=""mailto:{{ Entity.Person.Email }}"">{{ Entity.Person.Email }}</a><br />
            //        {% endif %}

            //        {% assign mobilePhone = Entity.Person.PhoneNumbers | Where:''NumberTypeValueId'', 12 | Select:''NumberFormatted'' %}
            //        {% if mobilePhone != empty %}
            //            Cell: {{ mobilePhone }}<br />
            //        {% endif %}

            //        {% assign homePhone = Entity.Person.PhoneNumbers | Where:''NumberTypeValueId'', 13 | Select:''NumberFormatted'' %}
            //        {% if homePhone != empty %}
            //            Home: {{ homePhone }}<br />
            //        {% endif %}
            //    </td>
            //</tr>', '0323D1DE-616B-4060-AF72-1F17FEEA648F' )

            //    END
            //" );

            // DT: Add Connection Counts
            // Moved to 201711210033592_InteractionTemplateAndCampaignFields
            //            Sql( @"
            //    DECLARE @EntityTypeId int = ( SELECT TOP 1 [Id] FROM [EntityType] WHERE [Name] = 'Rock.Model.Block' )
            //    DECLARE @BlockTypeId int = ( SELECT TOP 1 [Id] FROM [BlockType] WHERE [Path] = '~/Blocks/Connection/MyConnectionOpportunities.ascx' )
            //    DECLARE @AttributeId int = ( SELECT TOP 1 [Id] FROM [Attribute] WHERE [EntityTypeId] = @EntityTypeId AND [EntityTypeQualifierColumn] = 'BlockTypeId' AND [EntityTypeQualifierValue] = CAST( @BlockTypeId AS varchar ) AND [Key] = 'OpportunitySummaryTemplate' )
            //    UPDATE [AttributeValue] SET [Value] = '<span class=""item - count"" title=""There are { { ''active connection'' | ToQuantity:OpportunitySummary.TotalRequests } } in this opportunity."">{{ OpportunitySummary.TotalRequests | Format:''#,###,##0'' }}</span>' + [Value]
            //    WHERE [AttributeId] = @AttributeId AND [Value] NOT LIKE '<span class=""item-count""%'
            //" );

            // SK:  Typo on Person Badge
            // Moved to core migration: 201711271827181_V7Rollup
            //            Sql( @"
            //    DECLARE @PersonBadgeId INT = (SELECT TOP 1 [Id] FROM [PersonBadge] WHERE [Guid]='7FC986B9-CA1E-CBB7-4E63-C79EAC34F39D')
            //    DECLARE @AttributeId INT = (SELECT TOP 1 [Id] FROM [Attribute] WHERE [Guid] = '01C9BA59-D8D4-4137-90A6-B3C06C70BBC3')
            //    UPDATE [AttributeValue] SET [Value] = REPLACE(Value,'{{ Person.NickName}} become an eRA on','{{ Person.NickName}} became an eRA on') 
            //    WHERE [AttributeId] = @AttributeId AND [EntityId] = @PersonBadgeId
            //" );

            // DT: MP: Mask Account Number
            // in 201709131136468_SafeSenderUpdate
            //            Sql( @"
            //    UPDATE FinancialPaymentDetail SET AccountNumberMasked = REPLICATE('*', len(AccountNumberMasked) - 4) + Right(AccountNumberMasked, 4)
            //    WHERE AccountNumberMasked IS NOT NULL
            //    AND REPLICATE('*', len(AccountNumberMasked) - 4) + Right(AccountNumberMasked, 4) != AccountNumberMasked

            //    UPDATE FinancialPersonBankAccount SET AccountNumberMasked = REPLICATE('*', len(AccountNumberMasked) - 4) + Right(AccountNumberMasked, 4)
            //    WHERE AccountNumberMasked IS NOT NULL
            //    AND REPLICATE('*', len(AccountNumberMasked) - 4) + Right(AccountNumberMasked, 4) != AccountNumberMasked
            //" );

            // JE: Rename 'Giving Analysis' -> 'Giving Analytics'
            // Moved to core migration: 201711271827181_V7Rollup
            //            Sql( @"
            //    UPDATE [BlockType] SET [Name] = 'Giving Analytics'
            //    WHERE [Path] = '~/Blocks/Finance/GivingAnalytics.ascx'
            //" );

            // DT: Fix GroupFinder Map values
            // Moved to core migration: 201711271827181_V7Rollup
            //            Sql( @"
            //    DECLARE @AttributeId int = ( SELECT TOP 1 [Id] FROM [Attribute] WHERE [Guid] = '9DA54BB6-986C-4723-8FE1-E3EF53119C6A' )
            //    UPDATE [AttributeValue] SET [Value] = 
            //	    REPLACE( REPLACE( REPLACE( [Value], 
            //		    '{% if LinkedPages.GroupDetailPage != '''' %}', '{% if LinkedPages.GroupDetailPage and LinkedPages.GroupDetailPage != '''' %}' ),
            //		    '{% if LinkedPages.RegisterPage != '''' %}', '{% if LinkedPages.RegisterPage and LinkedPages.RegisterPage != '''' %}' ),
            //		    '{% if Location.FormattedHtmlAddress && Location.FormattedHtmlAddress != '''' %}', '{% if Location.FormattedHtmlAddress and Location.FormattedHtmlAddress != '''' %}' )
            //    WHERE [AttributeId] = @AttributeId
            //" );

            // MP: Fix Workflow Form Notification system email (for modified ones too)
            // in 201710131721219_InteractionRelatedEntity
            //            Sql( @"
            //    /* Fix Workflow Form Notification system email by passing 'Command' instead of 'action' to the Workflow Entry block. */
            //    /* Also pass ActionId so Workflow Entry block can target the exact User Entry Form if given. */
            //    UPDATE SystemEmail SET [Body] = REPLACE( [Body], 
            //        '{% capture ButtonLinkReplace %}{{ ''Global'' | Attribute:''InternalApplicationRoot'' }}WorkflowEntry/{{ Workflow.WorkflowTypeId }}?WorkflowGuid={{ Workflow.Guid }}&action={{ button.Name }}{% endcapture %}' ,
            //        '{% capture ButtonLinkReplace %}{{ ''Global'' | Attribute:''InternalApplicationRoot'' }}WorkflowEntry/{{ Workflow.WorkflowTypeId }}?WorkflowGuid={{ Workflow.Guid }}&ActionId={{ Action.Id }}&Command={{ button.Name }}{% endcapture %}'
            //    )
            //    WHERE [Guid] = '88C7D1CC-3478-4562-A301-AE7D4D7FFF6D'
            //    AND [BODY] like '%{% capture ButtonLinkReplace %}{{ ''Global'' | Attribute:''InternalApplicationRoot'' }}WorkflowEntry/{{ Workflow.WorkflowTypeId }}?WorkflowGuid={{ Workflow.Guid }}&action={{ button.Name }}{% endcapture %}%'
            //" );

            // JE: Update the CronExpression for Download Payments
            // Moved to core migration: 201711271827181_V7Rollup
            //            Sql( @"
            //    UPDATE [ServiceJob] SET [CronExpression] = '0 0 5 1/1 * ? *'
            //    WHERE [Guid] = '43044F38-F357-4CF4-995D-C60D4724C97E' 
            //    AND [CronExpression] = '0 0 5 ? * MON-FRI *'
            //" );
        }

        /// <summary>
        /// The commands to undo a migration from a specific version
        /// </summary>
        public override void Down()
        {
        }
    }
}
