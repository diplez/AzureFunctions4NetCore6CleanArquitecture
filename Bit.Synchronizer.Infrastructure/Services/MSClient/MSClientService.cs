using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Subscription.Domain.Common.Dto.Response.MSClient;
using Bit.Subscription.Domain.Common.Interfaces.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.MSClient
{
    public class MSClientService : IMSClientService
    {
        public readonly MSClientConfiguration _configuration;

        public MSClientService(MSClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ClientResponse> GetClientByIdAsync(Guid Id)
        {
            string baseUrl = $"{_configuration.URLBase}getClientById/{Id}";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<ClientResponse>>(response.Content);

                if (dto.Success)
                {
                    return dto.Result;
                }

                throw new ApplicationException(response.ErrorMessage);
            }
            else
            {
                throw new ApplicationException(response.Content);
            }
        }

        /// <summary>
        /// Obtiene datos de asociacion client partner
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ClientPartnerResponse> GetClientPartnerById(Guid Id)
        {
            
            string baseUrl = $"{_configuration.URLBase}getClientPartnerById/{Id}";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<ClientPartnerResponse>>(response.Content);

                if (dto.Success)
                {
                    return dto.Result;
                }

                throw new ApplicationException(response.ErrorMessage);
            }
            else
            {
                throw new ApplicationException(response.Content);
            }            
        }

        /// <summary>
        /// Obtiene todas las asociaciones de un cliente segun el identificador
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClientPartnerResponse>> GetClientPartnersByClientId(Guid Id)
        {
            try
            {
                string baseUrl = $"{_configuration.URLBase}getAllClientPartnerByClientId/{Id}";
                RestClient client = new RestClient(baseUrl);

                RestRequest request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");

                var response = await client.ExecuteAsync(request, Method.GET);

                if (response.IsSuccessful)
                {
                    var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<IEnumerable<ClientPartnerResponse>>>(response.Content);

                    return dto.Result;
                }
                else
                {
                    throw new ApplicationException(response.Content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"A ocurrido un error => {ex}");
            }
        }
    }
}
