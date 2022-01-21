using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto
{
    public class LicenceDto
    {
        [JsonProperty(PropertyName = nameof(Id))]
        public Guid Id { set; get; }

        [JsonProperty(PropertyName = nameof(Name))]
        public string Name { set; get; }

        [JsonProperty(PropertyName = nameof(FriendyName))]
        public string FriendyName { set; get; }

        [JsonProperty(PropertyName = nameof(TermDuration))]
        public string TermDuration { set; get; }

        [JsonProperty(PropertyName = nameof(Cost))]
        public double Cost { set; get; }

        [JsonProperty(PropertyName = nameof(MinimumQuantity))]
        public int MinimumQuantity { set; get; }

        [JsonProperty(PropertyName = nameof(MaximumQuantity))]
        public int MaximumQuantity { set; get; }

        [JsonProperty(PropertyName = nameof(IsTrial))]
        public bool IsTrial { set; get; }

        [JsonProperty(PropertyName = nameof(ProductId))]
        public string ProductId { set; get; }

        [JsonProperty(PropertyName = nameof(BillingType))]
        public string BillingType { set; get; }

        [JsonProperty(PropertyName = nameof(SupportedBillingCycles))]
        public List<string> SupportedBillingCycles { set; get; }

        [JsonProperty(PropertyName = nameof(CatalogName))]
        public string CatalogName { set; get; }

        [JsonProperty(PropertyName = nameof(CatalogItemId))]
        public string CatalogItemId { set; get; }

        [JsonProperty(PropertyName = nameof(CreatedAt))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = nameof(UpdatedAt))]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = nameof(SkuId))]
        public string SkuId { set; get; }

        [JsonProperty(PropertyName = nameof(SkuDescription))]
        public string SkuDescription { set; get; }

        [JsonProperty(PropertyName = nameof(ProductDescription))]
        public string ProductDescription { set; get; }

        [JsonProperty(PropertyName = nameof(IsAutoRenewable))]
        public bool IsAutoRenewable { set; get; }
        
    }
}
