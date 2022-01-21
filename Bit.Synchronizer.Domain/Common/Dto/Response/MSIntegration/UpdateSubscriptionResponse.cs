using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Response.MSIntegration
{
    public class UpdateSubscriptionResponse
    {
        public Guid Id { get; set; }
        public string OfferId { get; set; }
        public string EntitlementId { get; set; }
        public string OfferName { get; set; }
        public string FriendlyName { get; set; }
        public int Quantity { get; set; }
        public string UnitType { get; set; }
        public bool HasPurchasableAddons { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime CommitmentEndDate { get; set; }
        public string Status { get; set; }
        public bool AutoRenewEnabled { get; set; }
        public bool IsTrial { get; set; }
        public string BillingType { get; set; }
        public string BillingCycle { get; set; }
        public List<string> Actions { get; set; }
        public string TermDuration { get; set; }
        public bool IsMicrosoftProduct { get; set; }
        public bool AttentionNeeded { get; set; }
        public bool ActionTaken { get; set; }
        public string ContractType { get; set; }
        public Guid OrderId { get; set; }
        public AttributesCQSBCAS Attributes { get; set; }
    }

    public class AttributesCQSBCAS
    {
        public string Etag { get; set; }
        public string ObjectType { get; set; }
    }

    #region
    public class UpdateSubscriptionErrors
    {
        public int code { get; set; }
        public string description { get; set; }
        public IList<object> data { get; set; }
        public string source { get; set; }

    }
    #endregion
}
