using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Synchronizer.Domain.Common.Dto.Response.MSContract;
using Bit.Synchronizer.Domain.Common.Interfaces.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Infrastructure.Services.MSContract
{
    public class MSContractService : IMSContractService
    {
        public readonly MSContractConfiguration _configuration;

        public MSContractService(MSContractConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Obtiene los contratos segun el identificador de cliente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContractResponse>> GetAllContractsByClientId(Guid Id)
        {
            string baseUrl = $"{_configuration.URLBase}getAllContractByClientId/{Id}";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<IEnumerable<ContractResponse>>>(response.Content);

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

        public async Task<ContractResponse> GetContractByID(Guid id)
        {
            string baseUrl = $"{_configuration.URLBase}getContractById/{id}";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<ContractResponse>>(response.Content);

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
        /// Obtiene los contratos de segun el identificador de asociación 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContractResponse>> GetContractsByClientPartnerId(Guid Id)
        {
            string baseUrl = $"{_configuration.URLBase}getContractByClient/{Id}?Page=1&Results=1000";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request, Method.GET);

            if (response.IsSuccessful)
            {
                var dto = JsonConvert.DeserializeObject<ResponseResultAJAX<PagedResult<ContractResponse>>>(response.Content);

                if (dto.Success)
                {
                    return dto.Result.Items;
                }

                throw new ApplicationException(response.Content);
            }
            else
            {
                throw new ApplicationException(response.ErrorMessage);
            }
        }
    }
}
