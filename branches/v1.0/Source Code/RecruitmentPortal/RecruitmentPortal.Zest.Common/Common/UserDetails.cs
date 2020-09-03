using System;
using System.Collections.Generic;

namespace RecruitmentPortal.Zest.Common.Common
{
    public class UserDetails
    {
        public string AuthorizationToken { get; set; }
        public int SubscriptionID { get; set; }
        public int SubscriberID { get; set; }
        public int SubscriberBusinessID { get; set; }
        public int SubscriberPersonID { get; set; }
        public int SubscriberUserID { get; set; }
        public int NormalSubscriberUserID { get; set; }
        public int UserID { get; set; }
        public byte UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public byte LanguageID { get; set; }
        public int MySubscriberID { get; set; }
        public byte MyUserType { get; set; }
        public string MySubscriberLegalName { get; set; }
        public Guid ProfilePictureFileStreamID { get; set; }
        public bool ClearCache { get; set; }
        public string UserLoginHashKey { get; set; }
        public string WizardStep { get; set; }

        // For current location selected from dashboard.
        public Int64 CurrentSubscriberBusinessUnitID { get; set; }
        public string CurrentSubscriberBusinessUnitGSTIN { get; set; }
        public string CurrentSubscriberBusinessUnitLegalName { get; set; }
        public string CurrentSubscriberBusinessUnitGSTUserName { get; set; }
        public DateTime CurrentSubscriberBusinessUnitGSTNRegisteredDate { get; set; }
        public string CurrentSubscriberLegalName { get; set; }
        public string PanNumber { get; set; }
        public decimal CurrentSubscriberBusinessUnitPreviousFYTurnover { get; set; }
        public string CurrentSubscriberBusinessUnitEmailAddress { get; set; }

        // For location registraion details.
        public bool IsSupplier { get; set; }
        public bool IsCompounding { get; set; }
        public bool IsNonResident { get; set; }
        public bool IsISD { get; set; }
        public bool IsTDS { get; set; }
        public bool IsTCS { get; set; }
        public bool IsSEZ { get; set; }
        public bool IsQuarterlyReturnFiling { get; set; }

        // For other information & may vary base on subscriber.
        // One user can belongs to multiple subscriber.
        public bool IsInvited { get; set; }
        public List<string> UserBusinessUnitWiseRightsDetails { get; set; }
        public string AllowedIPAddress { get; set; }
        public bool IsAllowMyUserToEditImportData { get; set; }
        public bool IsAllowSMSFunctionalityToSubscriber { get; set; }
        public bool IsAllowBulkSearchTaxpayer { get; set; }
        public bool IsAllowInvoiceGeneration { get; set; }
        public bool IsAllowVendorAuthorization { get; set; }
        public bool IsAllowEWayBill { get; set; }
        public bool IsImpersonateRequest { get; set; }
        public bool IsOnDemandDashboardLoad { get; set; }
        public DateTime? AccountLockExpiry { get; set; }
        public string CustomGSPClientID { get; set; }
        public string CustomGSPClientSecret { get; set; }
        public long ParentSubscriberBusinessUnitID { get; set; }
        public string CurrentSubscriberBusinessUnitTradeName { get; set; }
        public decimal? CurrentSubscriberBusinessUnitQuarterlyTurnover { get; set; }
        public byte ApiGatewayID { get; set; }
        public byte CurrentApiGatewayID { get; set; }
    }
}
