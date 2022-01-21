using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Response.MSIntegration
{
    public class ProductoSkusResponse
    {
        [JsonProperty(PropertyName = nameof(Id))]
        public string Id { get; set; }

        [JsonProperty(PropertyName = nameof(ProductId))]
        public string ProductId { get; set; }

        [JsonProperty(PropertyName = nameof(Title))]
        public string Title { get; set; }

        [JsonProperty(PropertyName = nameof(Description))]
        public string Description { get; set; }

        [JsonProperty(PropertyName = nameof(MinimumQuantity))]
        public int MinimumQuantity { get; set; }

        [JsonProperty(PropertyName = nameof(MaximumQuantity))]
        public int MaximumQuantity { get; set; }

        [JsonProperty(PropertyName = nameof(IsTrial))]
        public bool IsTrial { get; set; }

        [JsonProperty(PropertyName = nameof(SupportedBillingCycles))]
        public List<string> SupportedBillingCycles { get; set; }

        [JsonProperty(PropertyName = nameof(PurchasePrerequisites))]
        public List<string> PurchasePrerequisites { get; set; }

        [JsonProperty(PropertyName = nameof(Actions))]
        public List<string> Actions { get; set; }

        [JsonProperty(PropertyName = nameof(DynamicAttributes))]
        public DynamicAttributes DynamicAttributes { get; set; }
    }

    public class DynamicAttributes
    {
        [JsonProperty(PropertyName = nameof(IsMicrosoftProduct))]
        public bool IsMicrosoftProduct { get; set; }

        [JsonProperty(PropertyName = nameof(BillingType))]
        public string BillingType { get; set; }

        [JsonProperty(PropertyName = nameof(IsAddon))]
        public bool IsAddon { get; set; }

        [JsonProperty(PropertyName = nameof(PrerequisiteSkus))]
        public List<string> PrerequisiteSkus { get; set; }

        [JsonProperty(PropertyName = nameof(Rank))]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = nameof(HasAddOns))]
        public bool HasAddOns { get; set; }

        [JsonProperty(PropertyName = nameof(IsAutoRenewable))]
        public bool IsAutoRenewable { get; set; }

        [JsonProperty(PropertyName = nameof(UpgradeTargetOffers))]
        public object UpgradeTargetOffers { get; set; }

        [JsonProperty(PropertyName = nameof(ConversionTargetOffers))]
        public List<object> ConversionTargetOffers { get; set; }

        [JsonProperty(PropertyName = nameof(UnitType))]
        public string UnitType { get; set; }

        [JsonProperty(PropertyName = nameof(LimitUnitOfMeasure))]
        public string LimitUnitOfMeasure { get; set; }

        [JsonProperty(PropertyName = nameof(Limit))]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = nameof(ReselleeQualifications))]
        public List<object> ReselleeQualifications { get; set; }

        [JsonProperty(PropertyName = nameof(ResellerQualifications))]
        public List<object> ResellerQualifications { get; set; }
    }
}
