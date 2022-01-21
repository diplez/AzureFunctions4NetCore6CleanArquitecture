using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Subscription.Domain.Common.Dto.Request.MSIntegration;
using Bit.Subscription.Domain.Common.Dto.Response.MSIntegration;
using Bit.Subscription.Domain.Common.Interfaces.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.MSIntegration
{
    public class MSIntegrationService : IMSIntegrationService
    {
        public readonly MSIntegrationConfiguration _configuration;

        public MSIntegrationService(MSIntegrationConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Obtiene los productos office por pais y tipo de servicio
        /// </summary>
        /// <param name="country"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductResponse>> getProductsByCountryAndTypeService(string country, string service)
        {
            string baseUrl = $"{_configuration.URLBase}getproductsByCountryAndType?Country={country}&TypeService={service}";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<IEnumerable<ProductResponse>>>(response.Content);

                if (dto.Success)
                {
                    return dto.Result;
                }

                throw new ApplicationException(response.Content);
            }
            else
            {
                throw new ApplicationException(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Obtiene los skus de cada producto 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="country"></param>
        /// <param name="segment"></param>
        /// <param name="reservationScope"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductoSkusResponse>> getproductsSkusByCountry(string productId, string country, string segment, string reservationScope)
        {
            string segmentParam = string.IsNullOrEmpty(segment) ? "" : $"&Segment={segment}";
            string reservationScopeParam = string.IsNullOrEmpty(reservationScope) ? "" : $"&ReservationScope={reservationScope}";

            string baseUrl = $"{_configuration.URLBase}getproductsSkusByCountry?ProductID={productId}&Country={country}{segmentParam}{reservationScopeParam}";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<IEnumerable<ProductoSkusResponse>>>(response.Content);

                if (dto.Success)
                {
                    return dto.Result;
                }

                throw new ApplicationException(response.Content);
            }
            else
            {
                throw new ApplicationException(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Permite crear una solicitud de suscripción
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreateSubscriptionResponse> createSubscriptionByCustomer(Guid CustomerId, RequestSubscriptionMI req)
        {
            string baseUrl = $"{_configuration.URLBase}";
            RestClient client = new RestClient($"{baseUrl}createsubscription/{CustomerId}");

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(req);

            var response = await client.ExecuteAsync(request, Method.POST);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException(response.ErrorMessage);
            }

            var result = JsonConvert.DeserializeObject<ResponseResultAJAX<CreateSubscriptionResponse>>(response.Content);

            if (!result.Success) {
                throw new ApplicationException(result.Error);
            }

            return result.Result;
        }

        /// <summary>
        /// Permite actualizar una suscripcion segun el cliente 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="SubscriptionID"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<UpdateSubscriptionResponse> updateRequestSubscription(Guid CustomerId, Guid SubscriptionID, UpdateSubscriptionRequest req)
        {
            RestClient client = new RestClient($"{_configuration.URLBase}updatesubscription/{CustomerId}/{SubscriptionID}");

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(req);

            var response = await client.ExecuteAsync(request, Method.POST);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException(response.ErrorMessage);
            }

            var result = JsonConvert.DeserializeObject<ResponseResultAJAX<UpdateSubscriptionResponse>>(response.Content);

            if (!result.Success) { 
                var errorCustom = JsonConvert.DeserializeObject<UpdateSubscriptionErrors>(result.Error);
                if (errorCustom.description != null) {
                    throw new ApplicationException(errorCustom.description);
                }
                throw new ApplicationException(result.Error);
            }

            return result.Result;
        }
    }
}
