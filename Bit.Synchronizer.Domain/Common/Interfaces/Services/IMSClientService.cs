using Bit.Subscription.Domain.Common.Dto.Response.MSClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Interfaces.Services
{
    public interface IMSClientService
    {
        Task<ClientPartnerResponse> GetClientPartnerById(Guid Id);

        Task<ClientResponse> GetClientByIdAsync(Guid Id);

        Task<IEnumerable<ClientPartnerResponse>> GetClientPartnersByClientId(Guid Id);
    }
}
