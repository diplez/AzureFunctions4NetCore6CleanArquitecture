using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Request.MSIntegration
{
    public class RequestSubscriptionMI
    {        
        public IEnumerable<CreateOrderCarMIRequest> lineItems { set; get; }
    }
    public class CreateOrderCarMIRequest
    {
        public int Id { get; set; }
        public string CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public string BillingCycle { get; set; }
        public string TermDuration { get; set; }
        public ProvisioningContextMI? ProvisioningContext { get; set; }
        public RenewsMITo? RenewsTo { get; set; }
    }

    public class ProvisioningContextMI
    {
        public string SubscriptionId { get; set; }
        public string Scope { get; set; }
    }

    public class RenewsMITo
    {
        public string TermDuration { get; set; }
    }
}
