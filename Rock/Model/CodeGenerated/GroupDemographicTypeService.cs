//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
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
using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// GroupDemographicType Service class
    /// </summary>
    public partial class GroupDemographicTypeService : Service<GroupDemographicType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDemographicTypeService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public GroupDemographicTypeService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( GroupDemographicType item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class GroupDemographicTypeExtensionMethods
    {
        /// <summary>
        /// Clones this GroupDemographicType object to a new GroupDemographicType object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static GroupDemographicType Clone( this GroupDemographicType source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as GroupDemographicType;
            }
            else
            {
                var target = new GroupDemographicType();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another GroupDemographicType object to this GroupDemographicType object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this GroupDemographicType target, GroupDemographicType source )
        {
            target.Id = source.Id;
            target.ComponentEntityTypeId = source.ComponentEntityTypeId;
            target.Description = source.Description;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GroupTypeId = source.GroupTypeId;
            target.IsAutomated = source.IsAutomated;
            target.LastRunDurationSeconds = source.LastRunDurationSeconds;
            target.Name = source.Name;
            target.RoleFilter = source.RoleFilter;
            target.RunOnPersonUpdate = source.RunOnPersonUpdate;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}
