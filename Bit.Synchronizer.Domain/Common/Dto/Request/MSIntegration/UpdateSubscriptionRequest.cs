using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Request.MSIntegration
{
    public class UpdateSubscriptionRequest
    {
        //public string FriendlyName { get; set; }
        public int Quantity { get; set; }
        //public string UnitType { get; set; }
       // public string HasPurchasableAddons { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime EffectiveStartDate { get; set; }
        //public DateTime CommitmentEndDate { get; set; }
        //public string Status { get; set; }
        //public bool AutoRenewEnabled { get; set; }
        //public bool IsTrial { get; set; }
        //public string BillingType { get; set; }
        //public string BillingCycle { get; set; }
        //public string TermDuration { get; set; }
        //public string IsMicrosoftProduct { get; set; }
        //public string ContractType { get; set; }
        public string OrderId { get; set; }
        //public AttributesCQSR Attributes { get; set; }
    }

    public class AttributesCQSR
    {
        public string ObjectType { get; set; }
    }
}
