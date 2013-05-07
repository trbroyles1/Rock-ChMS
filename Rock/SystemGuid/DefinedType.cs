﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;

namespace Rock.SystemGuid
{
    /// <summary>
    /// Static Guids used by the Rock ChMS application
    /// </summary>
    public static class DefinedType
    {
        /// <summary>
        /// Guid for Financial Currency Type
        /// </summary>
        public static Guid FINANCIAL_CURRENCY_TYPE { get { return new Guid( "1D1304DE-E83A-44AF-B11D-0C66DD600B81" ); } }

        /// <summary>
        /// Guid for Financial Credit Card Type
        /// </summary>
        public static Guid FINANCIAL_CREDIT_CARD_TYPE { get { return new Guid( "2BD4FFB0-6C7F-4890-8D08-00F0BB7B43E9" ); } }

        /// <summary>
        /// Guid for Financial Source Type
        /// </summary>
        public static Guid FINANCIAL_SOURCE_TYPE { get { return new Guid( "4F02B41E-AB7D-4345-8A97-3904DDD89B01" ); } }

        /// <summary>
        /// Guid for Financial Fund Type
        /// </summary>
        public static Guid FINANCIAL_FUND_TYPE { get { return new Guid( "e388c12f-0d8c-4055-8a53-5dde824bf711" ); } }

        /// <summary>
        /// Guid for the types of Locations (such as Home, Main Office, etc)
        /// </summary>
        public static Guid LOCATION_LOCATION_TYPE { get { return new Guid( "2e68d37c-fb7b-4aa5-9e09-3785d52156cb" ); } }

        /// <summary>
        /// Guid for Marketing Campaign Audience Type
        /// </summary>
        public static Guid MARKETING_CAMPAIGN_AUDIENCE_TYPE { get { return new Guid( "799301A3-2026-4977-994E-45DC68502559" ); } }

        /// <summary>
        /// Metric Collection Frequency
        /// </summary>
        public static Guid METRIC_COLLECTION_FREQUENCY { get { return new Guid( "526CB333-2C64-4486-8469-7F7EA9366254" ); } }
        
        /// <summary>
        /// Guid for the types of Person Records (such as person, business, etc.)
        /// </summary>
        public static Guid PERSON_RECORD_TYPE { get { return new Guid( "26be73a6-a9c5-4e94-ae00-3afdcf8c9275" ); } }

        /// <summary>
        /// Guid for the types of Person Record Statuses (such as active, inactive, pending, etc.)
        /// </summary>
        public static Guid PERSON_RECORD_STATUS { get { return new Guid( "8522badd-2871-45a5-81dd-c76da07e2e7e" ); } }

        /// <summary>
        /// Guid for the types of Person Status Reasons (such as deceased, moved, etc.)
        /// </summary>
        public static Guid PERSON_RECORD_STATUS_REASON { get { return new Guid( "e17d5988-0372-4792-82cf-9e37c79f7319" ); } }

        /// <summary>
        /// Guid for the person status (such as member, attendee, participant, etc.)
        /// </summary>
        public static Guid PERSON_STATUS { get { return new Guid( "2e6540ea-63f0-40fe-be50-f2a84735e600" ); } }

        /// <summary>
        /// Guid for the types of Person Titles (such as Mr., Mrs., Dr., etc.)
        /// </summary>
        public static Guid PERSON_TITLE { get { return new Guid( "4784cd23-518b-43ee-9b97-225bf6e07846" ); } }

        /// <summary>
        /// Guid for the types of Person Suffixes (such as Jr., Sr., etc.)
        /// </summary>
        public static Guid PERSON_SUFFIX { get { return new Guid( "16f85b3c-b3e8-434c-9094-f3d41f87a740" ); } }

        /// <summary>
        /// Guid for the types of Person Marital Statuses (such as Married, Single, Divorced, Widowed, etc.)
        /// </summary>
        public static Guid PERSON_MARITAL_STATUS { get { return new Guid( "b4b92c3f-a935-40e1-a00b-ba484ead613b" ); } }

        /// <summary>
        /// Guid for the types of Person phone numbers (such as Primary, Secondary, etc.)
        /// </summary>
        public static Guid PERSON_PHONE_TYPE { get { return new Guid( "8345DD45-73C6-4F5E-BEBD-B77FC83F18FD" ); } }

    }
}