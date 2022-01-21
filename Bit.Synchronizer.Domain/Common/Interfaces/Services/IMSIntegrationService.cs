using Bit.Subscription.Domain.Common.Dto;
using Bit.Subscription.Domain.Common.Dto.Response;
using Bit.Domain.Common.Dto.Response.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit.Subscription.Domain.Common.Dto.Response.MSIntegration;
using Bit.Subscription.Domain.Common.Dto.Request.MSIntegration;

namespace Bit.Subscription.Domain.Common.Interfaces.Services
{
    public interface IMSIntegrationService
    {
        public Task<CreateSubscriptionResponse> createSubscriptionByCustomer(Guid CustomerId,RequestSubscriptionMI req);

        public Task<UpdateSubscriptionResponse> updateRequestSubscription(Guid CustomerId, Guid SubscriptionID, UpdateSubscriptionRequest req);

        public Task<IEnumerable<ProductResponse>> getProductsByCountryAndTypeService(string country, string service);

        public Task<IEnumerable<ProductoSkusResponse>> getproductsSkusByCountry(string productId, string country,string segment="", string reservationScope="");        
    }
}
