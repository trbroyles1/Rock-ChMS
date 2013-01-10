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
    /// PrayerRequest Service class
    /// </summary>
    public partial class PrayerRequestService : Service<PrayerRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrayerRequestService"/> class
        /// </summary>
        public PrayerRequestService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrayerRequestService"/> class
        /// </summary>
        public PrayerRequestService(IRepository<PrayerRequest> repository) : base(repository)
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
        public bool CanDelete( PrayerRequest item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static class PrayerRequestExtensionMethods
    {
        /// <summary>
        /// Copies all the entity properties from another PrayerRequest entity
        /// </summary>
        public static void CopyPropertiesFrom( this PrayerRequest target, PrayerRequest source )
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.RequestedByPersonId = source.RequestedByPersonId;
            target.CategoryId = source.CategoryId;
            target.Text = source.Text;
            target.Answer = source.Answer;
            target.EnteredDate = source.EnteredDate;
            target.ExpirationDate = source.ExpirationDate;
            target.GroupId = source.GroupId;
            target.AllowComments = source.AllowComments;
            target.IsUrgent = source.IsUrgent;
            target.IsPublic = source.IsPublic;
            target.IsActive = source.IsActive;
            target.IsApproved = source.IsApproved;
            target.FlagCount = source.FlagCount;
            target.PrayerCount = source.PrayerCount;
            target.ApprovedByPersonId = source.ApprovedByPersonId;
            target.ApprovedOnDate = source.ApprovedOnDate;
            target.Id = source.Id;
            target.Guid = source.Guid;

        }
    }
}