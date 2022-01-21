using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Response.MSIntegration
{
    public class CreateSubscriptionResponse
    {
        [JsonProperty(PropertyName = nameof(Orders))]
        public IEnumerable<CartCheckoutResponseCSR> Orders { set; get; }
    }

    public class CartCheckoutResponseCSR
    {
        [JsonProperty(PropertyName = nameof(Id))]
        public string Id { set; get; }

        [JsonProperty(PropertyName = nameof(AlternateID))]
        public string AlternateID { set; get; }

        [JsonProperty(PropertyName = nameof(CustomerID))]
        public Guid CustomerID { set; get; }

        [JsonProperty(PropertyName = nameof(BillingCycle))]
        public string BillingCycle { set; get; }

        [JsonProperty(PropertyName = nameof(CurrencyCode))]
        public string CurrencyCode { set; get; }

        [JsonProperty(PropertyName = nameof(CreationDate))]
        public DateTime CreationDate { get; set; }

        [JsonProperty(PropertyName = nameof(Status))]
        public string Status { get; set; }

        [JsonProperty(PropertyName = nameof(transactionType))]
        public string transactionType { get; set; }

        [JsonProperty(PropertyName = nameof(LineItems))]
        public IEnumerable<LineItemsCartCheckoutResponseCSR> LineItems { set; get; }
    }

    public class LineItemsCartCheckoutResponseCSR
    {
        [JsonProperty(PropertyName = nameof(LineItemNumber))]
        public int LineItemNumber { get; set; }

        [JsonProperty(PropertyName = nameof(OfferId))]
        public string OfferId { get; set; }

        [JsonProperty(PropertyName = nameof(SubscriptionId))]
        public Guid SubscriptionId { get; set; }

        [JsonProperty(PropertyName = nameof(TermDuration))]
        public string TermDuration { get; set; }

        [JsonProperty(PropertyName = nameof(TransactionType))]
        public string TransactionType { get; set; }

        [JsonProperty(PropertyName = nameof(FriendlyName))]
        public string FriendlyName { get; set; }

        [JsonProperty(PropertyName = nameof(Quantity))]
        public int Quantity { get; set; }
    }
}
